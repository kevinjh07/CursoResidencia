namespace CursoResidencia.Application.UpdateAula;

public class UpdateAulaCommand : IRequest
{
    public int Id { get; set; }
    public int ModuloId { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string LinkVideo { get; set; }
    public Situacao Situacao { get; set; }
}
