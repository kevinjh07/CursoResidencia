namespace CursoResidencia.Domain.Models;

public class SimuladoQuestaoProva
{
    public int SimuladoId { get; set; }
    public Simulado Simulado { get; set; }
    public long QuestaoProvaId { get; set; }
    public QuestaoProva QuestaoProva { get; set; }

    public SimuladoQuestaoProva()
    {

    }

    public SimuladoQuestaoProva(int simuladoId, long questaoProvaId)
    {
        SimuladoId = simuladoId;
        QuestaoProvaId = questaoProvaId;
    }
}
