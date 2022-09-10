namespace CursoResidencia.Domain.Models.Dto;

public class LoginResponse
{
    public string Token { get; set; }
    public DateTimeOffset Expiration { get; set; }
    public string RefreshToken { get; set; }
}
