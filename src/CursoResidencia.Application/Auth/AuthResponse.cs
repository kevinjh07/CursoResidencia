namespace CursoResidencia.Application.Auth;

public class AuthResponse
{
    public string Token { get; set; }
    public DateTimeOffset Expiration { get; set; }

    public AuthResponse(string token, DateTimeOffset expiration )
    {
        Token = token;
        Expiration = expiration;
    }
}
