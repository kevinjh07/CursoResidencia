namespace CursoResidencia.Application.CreateCurso;

public class CreateCursoCommand : IRequest<CreateCursoResult>
{
    public string Nome { get; set; }
    public int ProfessorId { get; set; }
}
