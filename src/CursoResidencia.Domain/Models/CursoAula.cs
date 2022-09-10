namespace CursoResidencia.Domain.Models;

public class CursoAula
{
    public int CursoId { get; set; }
    public Curso Curso { get; set; }

    public int AulaId { get; set; }
    public Aula Aula { get; set; }

    public DateTime Data { get; set; }
}