namespace CheckoutService.SemViolacao.Entities;

public class CheckoutItemWithProduct
{
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}