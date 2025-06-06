using CheckoutService.SemViolacao.Entities;

namespace CheckoutService.SemViolacao.Repositories;

internal class OrderRepository
{
    internal async Task<Order> SaveAsync(Order order)
    {
        Console.WriteLine($"Pedido saldo no banco: {order}");
        return order;
    }
}
