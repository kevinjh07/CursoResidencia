namespace CursoResidencia.Domain.Models;

public class QuestaoProva
{
    public long Id { get; set; }
    public int? Ano { get; set; }
    public string Enunciado { get; set; }
    public string AlternativaA { get; set; }
    public string AlternativaB { get; set; }
    public string AlternativaC { get; set; }
    public string AlternativaD { get; set; }
    public string AlternativaE { get; set; }
    public AlternativaQuestao AlternativaCorreta { get; set; }
    public string Anexo { get; set; }
    public string Comentario { get; set; }
    public string CodigoVimeo { get; set; }
    public Situacao Situacao { get; set; }
    public bool Anulada { get; set; }
    public int? ProvaEspecialidadeId { get; set; }
    public int? ProvaHospitalId { get; set; }
    public int OrdemExibicao { get; set; }
    public ICollection<RespostaQuestaoSimulado> RespostasQuestaoSimulado { get; set; }
    public ICollection<SimuladoQuestaoProva> SimuladoQuestoesProva { get; set; }
}