using CheckoutService.ComViolacao.Dtos;
using CheckoutService.ComViolacao.Entities;
using CheckoutService.ComViolacao.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutService.ComViolacao.Services;

internal class CheckoutService
{
    private readonly EstoqueService estoqueService;
    private ProductyRepository productRepository;
    private TaxCalculator taxCalculator;
    private ShippingService shippingService;
    private PaymentProcessor paymentProcessor;
    private string paymentStatus;
    private string paymentError;
    private OrderRepository orderRepository;

    public CheckoutService(
        EstoqueService estoqueService,
        ProductyRepository productRepository,
        TaxCalculator taxCalculator,
        ShippingService shippingService,
        PaymentProcessor paymentProcessor)
    {
        this.estoqueService = estoqueService;
        this.productRepository = productRepository;
        this.taxCalculator = taxCalculator;
        this.shippingService = shippingService;
        this.paymentProcessor = paymentProcessor;
    }

    public async Task<CheckoutResponse> ProcessCheckoutAsync(CheckoutDTO checkoutDTO)
    {

        // 1. Verificar o estoque
        var outOfStockItems = await estoqueService.CheckStockAsync(checkoutDTO.Items);

        if (outOfStockItems.Any())
        {
            throw new Exception($"Produtos fora de estoque: {string.Join(", ", outOfStockItems)}");
        }

        // 2. Buscar produtos e calcular subtotal
        var itemsWithProducts = await Task.WhenAll(
            checkoutDTO.Items.Select(async item => new CheckoutItemWithProduct
            {
                Product = await productRepository.FindByIdAsync(item.ProductId),
                Quantity = item.Quantity
            })
        );


        var subtotal = itemsWithProducts.Sum(item => item.Product.Price * item.Quantity);

        // 3. Calcular impostos
        var tax = taxCalculator.CalculateTax(subtotal);

        // 4. Calcular custo de envio
        var shippingCost = shippingService.CalculateShipping(subtotal);

        // 5. Processar pagamento
        try
        {
            await paymentProcessor.ProcessPaymentAsync(new PaymentRequest
            {
                UserId = checkoutDTO.UserId,
                Amount = subtotal + tax + shippingCost,
                PaymentInfo = checkoutDTO.PaymentInfo
            });
        }
        catch (Exception ex)
        {
            paymentStatus = "failed";
            paymentError = $"Erro no pagamento: {ex.Message}";
        }

        // 6. Criar pedido (Order)
        var order = new Order
        {
            UserId = checkoutDTO.UserId,
            Items = itemsWithProducts,
            TotalPrice = subtotal + tax + shippingCost,
            Tax = tax,
            ShippingCost = shippingCost,
            PaymentStatus = "success",
            PaymentError = paymentError
        };

        // 7. Registrar o pedido no repositório
        await orderRepository.SaveAsync(order);

        // 8. Retornar a resposta diretamente
        return new CheckoutResponse
        {
            OrderId = "generated_order_id", // Simulado
            TotalPrice = order.TotalPrice,
            ShippingCost = order.ShippingCost,
            Status = order.PaymentStatus,
            PaymentError = order.PaymentError
        };
    }
}

internal class CheckoutResponse
{
    public string OrderId { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal ShippingCost { get; set; }
    public string Status { get; set; }
    public string PaymentError { get; set; }
}

internal class PaymentProcessor
{
    internal async Task ProcessPaymentAsync(PaymentRequest paymentRequest)
    {
        throw new NotImplementedException();
    }
}

internal class PaymentRequest
{
    public string UserId { get; set; }

    public decimal Amount { get; set; }

    public PaymentInfo PaymentInfo { get; set; }
}


public class CheckoutItemWithProduct
{
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}