namespace DiscountCalculator.SemViolacao
{
    interface IDiscountStrategy
    {
        public decimal Calculate();
    }

    class PremiumDiscount : IDiscountStrategy
    {
        public decimal Calculate()
        {
            // Implementação do cálculo de desconto para clientes premium
            return 0.2m; // Exemplo: 20% de desconto
        }
    }

    class RegularDiscount : IDiscountStrategy
    {
        public decimal Calculate()
        {
            // Implementação do cálculo de desconto para clientes regulares
            return 0.1m; // Exemplo: 10% de desconto
        }
    }

    class NoDiscount : IDiscountStrategy
    {
        public decimal Calculate()
        {
            // Implementação do cálculo de desconto para clientes sem desconto
            return 0.0m; // Exemplo: 0% de desconto
        }
    }

    internal class DiscountCalculator
    {
        public decimal CalculateDiscount(IDiscountStrategy discountStrategy)
        {
            if (discountStrategy == null)
            {
                throw new ArgumentNullException(nameof(discountStrategy), "Discount strategy cannot be null");
            }
            return discountStrategy.Calculate();
        }
    }
}
