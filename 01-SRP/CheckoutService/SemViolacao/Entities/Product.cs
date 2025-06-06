namespace CheckoutService.SemViolacao.Entities;

public class Product
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Product(string id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}
