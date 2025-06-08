namespace ProcessadorDePagamento.ComViolacao;

internal class PaymentProcessor
{
    internal virtual string ProcessPayment(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero.");
        }
        // Simulate processing payment
        return $"Pagamento de R${amount:C} processado.";
    }
}

internal class CreditCardPaymentProcessor : PaymentProcessor
{
    internal override string ProcessPayment(decimal amount)
    {
        if (amount > 1000)
        {
            throw new Exception("Limite de pagamento no cartão excedido"); // restrição adicional
        }
        return base.ProcessPayment(amount);
    }
}
