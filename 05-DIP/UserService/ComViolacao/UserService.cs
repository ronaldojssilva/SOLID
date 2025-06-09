using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.ComViolacao;


// UserService (Alto Nível) com dependência forte no MySQLDatabase (Baixo Nível).
internal class UserService
{
    private readonly MySQLDatabase _database;

    public UserService()
    {
        _database = new MySQLDatabase(); // Dependência direta e forte
    }
    public void AddUser(string name)
    {
        _database.AddUser("users", name);
    }
}

// Classe de baixo nível (implementação específica)
internal class MySQLDatabase
{
    internal void AddUser(string table, string data)
    {
        Console.WriteLine($"Inserindo no banco: {table} - {data}");
    }
}