namespace CursoResidencia.Application.CreateAula;

public class CreateAulaResponse
{
    public int Id { get; set; }
    public int ModuloId { get; set; }
    public Modulo Modulo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string LinkVideo { get; set; }
    public Situacao Situacao { get; set; }
    public DateTime DataCadastro { get; set; }
}
