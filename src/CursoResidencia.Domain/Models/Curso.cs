namespace CursoResidencia.Domain.Models;

public class Curso
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public ICollection<CursoAula> CursoAulas { get; set; }
    public ICollection<VisualizacaoAula> VisualizacaoAulas { get; set; }
    public ICollection<ProfessorCurso> ProfessorCursos { get; set; }
    public ICollection<Simulado> Simulados { get; set; }
    public ICollection<Modulo> Modulos { get; set; }
    public Situacao Situacao { get; set; }

    public Curso(string nome, DateTime dataInicio, DateTime dataFim)
    {
        Nome = nome;
        DataInicio = dataInicio;
        DataFim = dataFim;
        DataCadastro = DateTime.Now;
        Situacao = Situacao.Ativo;
    }

    public Curso(int id, string nome, DateTime dataCadastro, DateTime dataInicio, DateTime dataFim, Situacao situacao)
    {
        Id = id;
        Nome = nome;
        DataCadastro = dataCadastro;
        DataInicio = dataInicio;
        DataFim = dataFim;
        Situacao = situacao;
    }

    public Curso()
    {

    }
}
