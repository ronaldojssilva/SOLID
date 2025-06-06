namespace CheckoutService.SemViolacao.Entities;

internal class Shipping
{
    public decimal CalculateShipping(decimal subtotal)
    {
        return subtotal < 300 ? 20 : 0; // Fretis grátis para pedidos acima de 300
    }
}
