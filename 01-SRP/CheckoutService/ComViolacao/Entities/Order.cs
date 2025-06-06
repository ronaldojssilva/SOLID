using CheckoutService.ComViolacao.Services;

namespace CheckoutService.ComViolacao.Entities;

internal class Order
{
    public string UserId { get; set; }
    public CheckoutItemWithProduct[] Items { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal Tax { get; set; }
    public decimal ShippingCost { get; set; }
    public string PaymentStatus { get; set; }
    public string PaymentError { get; set; }
}
