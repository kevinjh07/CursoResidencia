namespace CursoResidencia.Application.CreateModulo;

public class CreateModuloCommand : IRequest<CreateModuloResult>
{
    public string Nome { get; set; }
    public int CursoId { get; set; }
}
