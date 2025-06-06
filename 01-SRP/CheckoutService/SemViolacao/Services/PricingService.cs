using CheckoutService.SemViolacao.Dtos;
using CheckoutService.SemViolacao.Entities;
using CheckoutService.SemViolacao.Repositories;

namespace CheckoutService.SemViolacao.Services;

internal class PricingService
{
    private readonly ProductRepository productRepository;

    public PricingService(ProductRepository productyRepository)
    {
        this.productRepository = productyRepository;
    }

    public async Task<IEnumerable<CheckoutItemWithProduct>> GetItemsWithProducts(IEnumerable<Item> items)
    {
        var itemsWithProducts = await Task.WhenAll(
            items.Select(async item => new CheckoutItemWithProduct
            {
                Product = await productRepository.FindByIdAsync(item.ProductId),
                Quantity = item.Quantity
            })
        );

        return itemsWithProducts;
    }
}
