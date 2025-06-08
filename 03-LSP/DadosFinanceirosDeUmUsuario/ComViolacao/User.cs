namespace DadosFinanceirosDeUmUsuario.ComViolacao;

internal class User
{
    public string UserName { get; set; }
    public string FinancialData { get; set; } = "Dados Financeiros do usuário";

    public User(string userName, string financialData)
    {
        this.UserName = userName;
        this.FinancialData = financialData;
    }

    internal virtual bool HasAccess()
    {
        return true; // Por padrão, todos os usuários têm acesso.
    }

    internal virtual string GetFinancialData()
    {
        return FinancialData; // Retorna os dados financeiros do usuário.
    }
}

internal class  GuestUser : User { 
    public GuestUser(string userName) : base(userName, "Dados Financeiros do usuário") { }

    // Violação do Princípio de Substituição de Liskov (LSP)
    internal override bool HasAccess()
    {
        return false; // Usuários convidados não têm acesso aos dados financeiros.
    }

    // Sobrescrever o método para causar comportament inesperado
    internal override string GetFinancialData()
    {
        throw new UnauthorizedAccessException("Usuários convidados não posui dados financeiros."); // Simulando ausência de dados financeiros
    }
}