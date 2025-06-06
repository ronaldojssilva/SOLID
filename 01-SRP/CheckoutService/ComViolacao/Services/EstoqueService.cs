using CheckoutService.ComViolacao.Dtos;

namespace CheckoutService.ComViolacao.Services;

internal class EstoqueService
{
    private Dictionary<string, int> stock = new Dictionary<string, int>
        {
            { "1", 10 },
            { "2", 5 },
            { "3", 0 } // Exemplo de produto fora de estoque
        };

    internal async Task<IEnumerable<string>> CheckStockAsync(IEnumerable<Item> items)
    {
        var outOfStockItems = new List<string>();

        foreach (var item in items)
        {
            int availableQuantity = stock.TryGetValue(item.ProductId, out int quantity) ? quantity : 0;

            if (item.Quantity > availableQuantity)
            {
                outOfStockItems.Add(item.ProductId);
            }
        }
        return await Task.FromResult(outOfStockItems);
    }
}
