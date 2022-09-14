namespace CursoResidencia.Application.UpdateProfessor;

public class UpdateProfessorCommand : IRequest
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public Situacao Situacao { get; set; }
}
