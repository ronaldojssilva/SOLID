namespace PaymentService.SemViolacao;

interface ICreditCArdPaymentProcessor
{
    void ProcessCreditCardPaymentAmount(decimal amount);
    void ValidateCreditCard();
}

interface ILoanProcessor
{
    void ProcessLoan(decimal amount);
}

class CreditCardService : ICreditCArdPaymentProcessor
{
    public void ProcessCreditCardPaymentAmount(decimal amount)
    {
        throw new NotImplementedException();
    }
    public void ValidateCreditCard()
    {
        throw new NotImplementedException();
    }
}

class LoanService : ILoanProcessor
{
    public void ProcessLoan(decimal amount)
    {
        throw new NotImplementedException();
    }
}