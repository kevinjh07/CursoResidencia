namespace CursoResidencia.Domain.Models;

public class RefreshToken
{
    public int UserId { get; set; }
    public ApplicationUser User { get; set; }
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}