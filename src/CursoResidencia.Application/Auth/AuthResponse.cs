namespace CursoResidencia.Application.Auth;

public class AuthResponse
{
    public string Token { get; set; }
    public DateTimeOffset Expiration { get; set; }
    public string RefreshToken { get; set; }
}
