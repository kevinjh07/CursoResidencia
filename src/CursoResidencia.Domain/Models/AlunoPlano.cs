namespace CursoResidencia.Domain.Models;

public class AlunoPlano
{
    public int AlunoId { get; set; }
    public Aluno Aluno { get; set; }
    public int PlanoId { get; set; }
    public Plano Plano { get; set; }
    public DateTime DataCompra { get; set; }
    public SituacaoPlano Situacao { get; set; }
    public TipoPagamento TipoPagamento { get; set; }
}