using CheckoutService.ComViolacao.Entities;

namespace CheckoutService.ComViolacao.Repositories;

internal class ProductyRepository
{
    private List<Product> products =
    [
        new Product("1", "Produto 1", 100),
        new Product("2", "Produto 2", 200),
        new Product("3", "Produto 3", 300)
    ];

    public async Task<Product> FindByIdAsync(string id)
    {
        // Simula uma busca assíncrona
        await Task.Delay(100);
        Product? product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            throw new Exception($"Produto com ID {id} não encontrado.");
        }

        return product;
    }
}
