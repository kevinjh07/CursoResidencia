namespace CursoResidencia.Domain.Models;

public class Simulado
{
    public int Id { get; set; }
    public Aluno Aluno { get; set; }
    public int AlunoId { get; set; }
    public Modulo Modulo { get; set; }
    public int? ModuloId { get; set; }
    public int? SubModuloId { get; set; }
    public int? HospitalId { get; set; }
    public Curso Curso { get; set; }
    public int? CursoId { get; set; }
    public DateTime DataCriacao { get; set; }
    public ICollection<RespostaQuestaoSimulado> RespostasQuestaoSimulado { get; set; }
    public SituacaoProva SituacaoProva { get; set; }
    public ICollection<SimuladoQuestaoProva> SimuladoQuestoesProva { get; set; }
}