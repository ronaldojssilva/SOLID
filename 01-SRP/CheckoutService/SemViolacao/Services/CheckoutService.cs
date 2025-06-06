using CheckoutService.SemViolacao.Dtos;
using CheckoutService.SemViolacao.Entities;
using CheckoutService.SemViolacao.Repositories;

namespace CheckoutService.SemViolacao.Services;

internal class CheckoutService
{
    private TaxCalculator taxCalculator;
    private PaymentProcessor paymentProcessor;
    private string paymentStatus;
    private string? paymentError;
    private OrderRepository orderRepository;
    private StockValidator stockValidator;
    private PricingService pricingService;
    private Tax tax;
    private Shipping shipping;

    public CheckoutService(
        TaxCalculator taxCalculator,
        PaymentProcessor paymentProcessor,
        StockValidator stockValidator,
        PricingService pricingService,
        Tax tax,
        Shipping shipping)
    {
        this.taxCalculator = taxCalculator;
        this.paymentProcessor = paymentProcessor;
        this.stockValidator = stockValidator;
        this.pricingService = pricingService;
        this.tax = tax;
        this.shipping = shipping;
    }

    public async Task<CheckoutResponse> ProcessCheckoutAsync(CheckoutDTO checkoutDTO)
    {

        // 1. Verificar o estoque
        stockValidator.ValidateStockAsync(checkoutDTO.Items);

        // 2. Buscar produtos e calcular subtotal
        IEnumerable<CheckoutItemWithProduct> itemsWithProducts = await pricingService.GetItemsWithProducts(checkoutDTO.Items);

        var order = new Order(itemsWithProducts, this.tax, this.shipping);

        // 5. Processar pagamento
        var paymentResult =
            await paymentProcessor.ProcessPaymentAsync(new PaymentRequest
            {
                UserId = checkoutDTO.UserId,
                Amount = order.TotalPrice,
                PaymentInfo = checkoutDTO.PaymentInfo
            });

        paymentStatus = paymentResult.Success ? "paid" : "failed";
        paymentError = string.Empty;
        if (!paymentResult.Success)
        {
            paymentError = $"Erro ao processar pagamento {paymentResult.ErrorCode}";
        }
        order.ChangePaymentStatus(paymentStatus, paymentError);

        // 7. Registrar o pedido no repositório
        var savedOrder = await orderRepository.SaveAsync(order);

        var orderDto = savedOrder.ToDto();
        // 8. Retornar a resposta diretamente
        return new CheckoutResponse
        {
            OrderId = "generated_order_id", // Simulado
            TotalPrice = orderDto.TotalPrice,
            ShippingCost = orderDto.ShippingCost,
            Status = paymentStatus,
            PaymentError = paymentError
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