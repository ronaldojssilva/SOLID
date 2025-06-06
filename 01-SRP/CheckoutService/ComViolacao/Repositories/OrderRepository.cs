using CheckoutService.ComViolacao.Entities;

namespace CheckoutService.ComViolacao.Repositories;

internal class OrderRepository
{
    internal async Task SaveAsync(Order order)
    {
        Console.WriteLine($"Pedido saldo no banco: {order}");
    }
}
