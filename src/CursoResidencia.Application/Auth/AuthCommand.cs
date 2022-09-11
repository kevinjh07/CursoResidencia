namespace CursoResidencia.Application.Auth;

public class AuthCommand : IRequest<AuthResult>
{
    public string Email { get; set; }
    public string Senha { get; set; }
}
