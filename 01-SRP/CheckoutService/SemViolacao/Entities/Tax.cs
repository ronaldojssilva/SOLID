namespace CheckoutService.SemViolacao.Entities;

internal class Tax
{
    public decimal CalculateTax(decimal amount)
    {
        // Simula o cálculo de impostos
        return amount * 0.1m; // 10% de imposto
    }
}