namespace CursoResidencia.Domain.Models.Dto;

public class CursoDto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string NomeProfessor { get; set; }
    public IEnumerable<AulaDto> Aulas { get; set; }
}
