namespace CursoResidencia.Domain.Models;

public class Aula
{
    public int Id { get; set; }
    public int ModuloId { get; set; }
    public Modulo Modulo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string LinkVideo { get; set; }
    public Situacao Situacao { get; set; }
    public DateTime DataCadastro { get; set; }
    public ICollection<VisualizacaoAula> VisualizacaoAulas { get; set; }

    public Aula(int moduloId, string nome, string descricao, string linkVideo)
    {
        ModuloId = moduloId;
        Nome = nome;
        Descricao = descricao;
        LinkVideo = linkVideo;
        Situacao = Situacao.Ativo;
        DataCadastro = DateTime.Now;
    }

    public Aula()
    {

    }
}
