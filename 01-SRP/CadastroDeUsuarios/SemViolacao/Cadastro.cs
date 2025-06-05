namespace CadastroDeUsuarios.SemViolacao;

// aqui eu separo as responsabilidades de cadastro e consulta de usuário
// Nessa solução eu criei dois DTOs diferentes, um para cadastro e outro para consulta
// isso garante que cada DTO tem uma única responsabilidade e não mistura campos que não são necessários em ambos os contextos


// DTO de entrada para cadastro de usuário
record UserRegistrationDTO(
    string Name,
    string Email,
    string Password); //senha obrigatória na entrada

// DTO de saída para consulta de usuário
record UserResponseDTO(
    string Id,
    string Name,
    string Email,
    DateTime CreatedAt, // ID e CreatedAt são retornados na consulta   
    StatusEnum status); // Campo que faz sentido apenas na resposta

internal enum StatusEnum
{
    Active,
    Inactive,
    Suspended
}

// Serviço de cadastro de usuário
class UserRegistrationService
{
    public void RegisterUser(UserRegistrationDTO user)
    {
        if (string.IsNullOrWhiteSpace(user.Password))
        {
            throw new Exception("Senha é obrigatória");
        }
        Console.WriteLine($"Usuário registrado: {user}");
    }
}

// Serviço de consulta de usuário
class UserQueryService
{
    public UserResponseDTO GetUserById(string id)
    {
        return new UserResponseDTO(id, "Ronaldo", "ronaldo@email.com", DateTime.Now, StatusEnum.Active);
    }
}