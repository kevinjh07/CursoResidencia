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
    public Situacao Situacao { get; set; }

    public Curso(string nome, DateTime dataInicio, DateTime dataFim)
    {
        Nome = nome;
        DataInicio = dataInicio;
        DataFim = dataFim;
        DataCadastro = DateTime.Now;
        Situacao = Situacao.Ativo;
    }
}
