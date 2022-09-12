namespace CursoResidencia.Application.CreateProfessor;

public class CreateProfessorCommand : IRequest<CreateProfessorResult>
{
    public string Nome { get; set; }
    public string Email { get; set; }
}
