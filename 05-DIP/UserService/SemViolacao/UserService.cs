namespace UserService.SemViolacao;

// interface de abstração
interface IDatabase
{
    void AddUser(string table, string data);
}


// Implementação concreta para MySql
class MySQLDatabase : IDatabase
{
    public void AddUser(string table, string data)
    {
        Console.WriteLine($"Inserindo no banco MySql: {table} - {data}");
    }
}

// Implementação concreta para PostgreSQL
class PostgreSQLDatabase : IDatabase
{
    public void AddUser(string table, string data)
    {
        Console.WriteLine($"Inserindo no banco PostgreSQL: {table} - {data}");
    }
}

// UserService (Alto Nível) com dependência forte no MySQLDatabase (Baixo Nível).
internal class UserService
{
    private readonly IDatabase _database;

    public UserService(IDatabase database)
    {
        _database = database; // Dependência injetada, permitindo flexibilidade
    }

    public void AddUser(string name)
    {
        _database.AddUser("users", name);
    }
}
