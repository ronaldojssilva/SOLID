namespace CheckoutService.SemViolacao.Entities;

internal class Order
{
    private readonly IEnumerable<CheckoutItemWithProduct> items;
    private decimal subTotal;
    private decimal tax;
    private decimal shippingCost;
    private string paymentStatus = "pending";
    private string? paymentError = null;

    public Order(IEnumerable<CheckoutItemWithProduct> items, Tax tax, Shipping shipping)
    {
        this.items = items;
        subTotal = CalculateSubTotal();
        this.tax = tax.CalculateTax(subTotal);
        shippingCost = shipping.CalculateShipping(subTotal);
    }

    private decimal CalculateSubTotal()
    {
        return items.Sum(item => item.Product.Price * item.Quantity);
    }

    public decimal TotalPrice => subTotal + tax + shippingCost;

    public void ChangePaymentStatus(string status, string? error = null)
    {
        paymentStatus = status;
        paymentError = error;
    }

    public OrderDTO ToDto()
    {
        return new OrderDTO
        {
            Items = items.Select(item => new ItemDTO
            {
                ProductId = item.Product.Id,
                Quantity = item.Quantity,
                Price = item.Product.Price
            }).ToList(),
            TotalPrice = TotalPrice,
            Tax = tax,
            ShippingCost = shippingCost
        };
    }
}

internal class OrderDTO
{
    public List<ItemDTO> Items { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Tax { get; set; }
    public decimal ShippingCost { get; set; }
}

internal class ItemDTO
{
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}