namespace CursoResidencia.Application.CreateAula;

public class CreateAulaCommand : IRequest<CreateAulaResult>
{
    public int ModuloId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string LinkVideo { get; set; }
}
