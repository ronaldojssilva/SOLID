namespace PaymentService.ComViolacao;

interface IPaymentService
{
    void ProcessCreditCardPaymentAmount(decimal amount);

    void ValidateCreditCard();

    void ProcessLoan(decimal amount);
}

class CreditCardService : IPaymentService
{
    public void ProcessCreditCardPaymentAmount(decimal amount)
    {
        throw new NotImplementedException();
    }

    public void ProcessLoan(decimal amount)
    {
        //Não deveria existir. não existe empréstimo no cartão
        throw new NotImplementedException();
    }

    public void ValidateCreditCard()
    {
        throw new NotImplementedException();
    }
}


class LoanService : IPaymentService
{
    public void ProcessCreditCardPaymentAmount(decimal amount)
    {
        //Não deveria existit
        throw new NotImplementedException();
    }

    public void ProcessLoan(decimal amount)
    {
        throw new NotImplementedException();
    }

    public void ValidateCreditCard()
    {
        //Não deveria existir. não existe validação de cartão no empréstimo
        throw new NotImplementedException();
    }
}

/*
 Explicação da solução:

Neste exemplo, criamos uma interface `IPaymentService` que define três métodos: `ProcessCreditCardPaymentAmount`, `ValidateCreditCard` e `ProcessLoan`. 
Porém, forçar as classes a implementar todos os métodos viola o princípio da segregação de interface (ISP).

As classes `CreditCardService` e `LoanService` são obrigadas a impleentar métodos.
 
 */