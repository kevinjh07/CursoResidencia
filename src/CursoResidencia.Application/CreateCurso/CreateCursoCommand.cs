namespace CursoResidencia.Application.CreateCurso;

public class CreateCursoCommand : IRequest<CreateCursoResult>
{
    public string Nome { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
}
