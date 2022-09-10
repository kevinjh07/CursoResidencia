namespace CursoResidencia.Domain.Models;

public class VisualizacaoAula
{
    public int Id { get; set; }

    public int CursoId { get; set; }
    public Curso Curso { get; set; }

    public int AulaId { get; set; }
    public Aula Aula { get; set; }

    public int AlunoId { get; set; }
    public Aluno Aluno { get; set; }

    public DateTime Data { get; set; }
}