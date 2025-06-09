// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

//Criação de objetos
var mySqlUserService = new UserService.SemViolacao.UserService(new UserService.SemViolacao.MySQLDatabase());
var postgreSqlUserService = new UserService.SemViolacao.UserService(new UserService.SemViolacao.PostgreSQLDatabase());

// Demonstração de uso
mySqlUserService.AddUser("João");
postgreSqlUserService.AddUser("Maria");

/*
Nessa refatoração, introduzimos uma interface `IDatabase` que abstrai a operação de adicionar usuários. 
As classes `MySQLDatabase` e `PostgreSQLDatabase` implementam essa interface, permitindo que o `UserService` dependa apenas da abstração, 
não de uma implementação específica. 
Isso segue o princípio da Inversão de Dependência (DIP), onde módulos de alto nível não devem depender de módulos de baixo nível, mas ambos devem depender de abstrações.

Principais benefícios dessa abordagem:
  * Desacoplamento entre módulos de alto e baixo nível, permitindo que o `UserService` funcione com qualquer implementação de banco de dados que implemente a interface `IDatabase`.
  * Facilidade de substituição ou extensão do comportamento do banco de dados sem modificar o `UserService`.
  * Maior flexibilidade e testabilidade, pois podemos facilmente criar mocks ou stubs da interface `IDatabase` para testes unitários.
 */