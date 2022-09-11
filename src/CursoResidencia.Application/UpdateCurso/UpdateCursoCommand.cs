namespace CursoResidencia.Application.UpdateCurso;

public class UpdateCursoCommand : IRequest
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Situacao Situacao { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}
