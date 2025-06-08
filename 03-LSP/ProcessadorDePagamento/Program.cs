// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");


void HandlePayment(ProcessadorDePagamento.ComViolacao.PaymentProcessor processor, decimal amount)
{
    Console.WriteLine(processor.ProcessPayment(amount));
}

var defaultProcessor = new ProcessadorDePagamento.ComViolacao.PaymentProcessor();
var creditCardProcessor = new ProcessadorDePagamento.ComViolacao.CreditCardPaymentProcessor();

HandlePayment(defaultProcessor, 20000); // Processa normalmente
HandlePayment(creditCardProcessor, 20000); // Erro inesperado: "Limite de pagamento no cartão excedido"