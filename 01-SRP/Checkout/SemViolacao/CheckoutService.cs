namespace Checkout.SemViolacao
{
    // Se eu preciso de estratégia de checkout diferente, crio outra classe com uma lógica diferente que não seja: validar, calcular e processar.
    // exempo para ter outras estratégis seria ter checkout para B2B, B2C, ou checkout com desconto, etc.
    class CheckoutService
    {
        private readonly StockValidator _stockValidator;
        private readonly TaxCalculator _taxCalculator;
        private readonly PaymentProcessor _paymentProcessor;
        public CheckoutService(StockValidator stockValidator, TaxCalculator taxCalculator, PaymentProcessor paymentProcessor)
        {
            _stockValidator = stockValidator;
            _taxCalculator = taxCalculator;
            _paymentProcessor = paymentProcessor;
        }
        public void Checkout(Cart cart, string userId)
        {
            _stockValidator.Validate(cart);
            var totalWithTaxes = _taxCalculator.Calculate(cart);
            _paymentProcessor.Process(userId, totalWithTaxes);
        }
    }

    class StockValidator
    {
        public void Validate(Cart cart)
        {
            foreach (var item in cart.Items)
            {
                if (item.Stock < item.Quantity)
                {
                    throw new ArgumentException($"Produto {item.Name} sem estoque suficiente.");
                }
            }
        }
    }

    class TaxCalculator
    {
        public decimal Calculate(Cart cart)
        {
            decimal total = 0;
            foreach (var item in cart.Items)
            {
                total += item.Price * item.Quantity;
            }
            var tax = total * 0.1m;
            return total + tax;
        }
    }

    class PaymentProcessor
    {
        public void Process(string userId, decimal total)
        {
            Console.WriteLine($"Processando pagamento de R${total} para o usuário {userId}");
        }
    }
}
