namespace CursoResidencia.Domain.Models;

public class RespostaQuestaoSimulado
{
    public int Id { get; set; }
    public long QuestaoProvaId { get; set; }
    public QuestaoProva QuestaoProva { get; set; }
    public AlternativaQuestao? AlternativaSelecionada { get; set; }
    public Simulado Simulado { get; set; }
    public int SimuladoId { get; set; }
}