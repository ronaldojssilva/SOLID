// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var queryService = new CadastroDeUsuarios.ComViolacao.UserQueryService();
var user = queryService.GetUserById("123");
Console.WriteLine($"Usuário consultado {user}");