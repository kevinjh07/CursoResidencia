namespace CursoResidencia.Application.CreateCurso;

public class CreateCursoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public Situacao Situacao { get; set; }
    public int ProfessorId { get; set; }
}
