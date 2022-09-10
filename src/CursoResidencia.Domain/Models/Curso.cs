namespace CursoResidencia.Domain.Models;

public class Curso
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public bool Ativo { get; set; }
    public string Imagem { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public ICollection<Plano> Planos { get; set; }
    public ICollection<CursoAula> CursoAulas { get; set; }
    public ICollection<VisualizacaoAula> VisualizacaoAulas { get; set; }
    public ICollection<ProfessorCurso> ProfessorCursos { get; set; }
    public ICollection<Simulado> Simulados { get; set; }
    public Situacao Situacao { get; set; }
}
