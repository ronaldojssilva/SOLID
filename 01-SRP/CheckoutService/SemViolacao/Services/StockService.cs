using CheckoutService.SemViolacao.Dtos;

namespace CheckoutService.SemViolacao.Services;

internal record OutOfStockItem(string ProductId, int RequestedQuantity, int AvailableQuantity);

internal class StockValidator
{
    private readonly StockService stockService;

    public StockValidator(StockService stockService)
    {
        this.stockService = stockService;
    }

    public async void ValidateStockAsync(IEnumerable<Item> items)
    {
        var outOfStockItems = await stockService.CheckStockAsync(items);

        if (outOfStockItems.Any())
        {
            throw new Exception($"Produtos fora de estoque: {string.Join(", ", outOfStockItems)}");
        }

    }
}

internal class StockService
{
    private Dictionary<string, int> stock = new Dictionary<string, int>
        {
            { "1", 10 },
            { "2", 5 },
            { "3", 0 } // Exemplo de produto fora de estoque
        };

    internal async Task<IEnumerable<OutOfStockItem>> CheckStockAsync(IEnumerable<Item> items)
    {
        var outOfStockItems = new List<OutOfStockItem>();

        foreach (var item in items)
        {
            int availableQuantity = stock.TryGetValue(item.ProductId, out int quantity) ? quantity : 0;

            if (item.Quantity > availableQuantity)
            {
                outOfStockItems.Add(new OutOfStockItem(item.ProductId, item.Quantity, availableQuantity));
            }
        }
        return await Task.FromResult(outOfStockItems);
    }
}

