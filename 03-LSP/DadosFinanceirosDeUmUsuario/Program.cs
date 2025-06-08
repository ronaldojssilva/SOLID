// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

// Função que processa o pagamento
void makePayment(DadosFinanceirosDeUmUsuario.ComViolacao.User user, decimal amount)
{
    Console.WriteLine($"Iniciando pagamento para {user.UserName} no valor de R${amount.ToString()}");

	try
	{
		// Tentando acessar os dados financeiros, independentemente de "hasAccess"
		var financialData = user.GetFinancialData();
        Console.WriteLine($"Dados financeiros obtidos: {financialData}");
        Console.WriteLine($"Pagamento de R${amount.ToString()} processado com sucesso.");
    }
	catch (Exception error)
	{
        Console.WriteLine($"Erro ao processar pagamento para {user.UserName}: {error.Message}");
		throw;
	}
}

// Testando com diferentes tipos de usuários
var regularUser = new DadosFinanceirosDeUmUsuario.ComViolacao.User("João", "Dados Financeiros do João");
var guestUser = new DadosFinanceirosDeUmUsuario.ComViolacao.GuestUser("Visitante");

makePayment(regularUser, 100.00m); // Deve funcionar normalmente
// Saída esperada:
// Iniciando pagamento para João no valor de R$100.00
// Dados financeiros obtidos: Dados Financeiros do João
// Pagamento de R$100.00 processado com sucesso.

makePayment(guestUser, 50.00m); // Deve lançar uma exceção
// Comportamento inesperado (erro):
// Iniciando pagamento para Visitante no valor de R$50.00
// Erro ao processar pagamento para Visitante: Usuários convidados não posui dados financeiros.