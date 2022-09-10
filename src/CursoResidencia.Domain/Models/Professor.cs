namespace CursoResidencia.Domain.Models;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string MiniCurriculo { get; set; }
    public bool PermiteTutoria { get; set; }
    public Situacao Situacao { get; set; }
    public string Imagem { get; set; }
    public int? UsuarioId { get; set; }
    public ApplicationUser Usuario { get; set; }
    public ICollection<ProfessorCurso> ProfessorCursos { get; set; }
    public ICollection<Aula> Aulas { get; set; }
}