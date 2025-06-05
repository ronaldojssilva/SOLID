namespace CadastroDeUsuarios.ComViolacao;

// Aqui o problema é que estou usando o mesmo DTO para cadastrar e consultar
// Se eu tiver uma razação de mudança para registrar um usuário ou
// consultar um usuário, eu vou ter que mudar o DTO,
// siginifca que o dto tem razões diferentes para mudar, se eles tem razão diferentes para mudar, estão quebrando o SRP
// Para cadastrar eu não preciso do ID
// para consultar não precisar retornar o password
// UserDTO tem campos que não vão ser usados em ambos os casos, porque esta sendo usada em contextos diferentes

record UserDto(
string? Id,
string Name,
string Email,
string? Password,
DateTime? CreatedAt);


// serviço de cadastro de usuário
class UserRegistrationService {
    public void RegisterUser(UserDto user) {
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
    public UserDto GetUserById(string id)
    {
        return new UserDto(id, "Ronaldo", "ronaldo@email.com", string.Empty, DateTime.Now);
    }
}

