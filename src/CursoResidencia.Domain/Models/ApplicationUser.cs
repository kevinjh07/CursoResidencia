using Microsoft.AspNetCore.Identity;

namespace CursoResidencia.Domain.Models;

public class ApplicationUser : IdentityUser<int>
{
    public string Nome { get; set; }
    public Situacao Situacao { get; set; }
    public Aluno Aluno { get; set; }
    public Professor Professor { get; set; }
    public DateTime? UltimoLogin { get; set; }
    public ICollection<RefreshToken> RefreshTokens { get; set; }
}
