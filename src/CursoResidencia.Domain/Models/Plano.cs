namespace CursoResidencia.Domain.Models;

public class Plano
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public bool Ativo { get; set; }
    public int CursoId { get; set; }
    public Curso Curso { get; set; }
    public int DiaVencimentoParcela { get; set; }
    public decimal ValorMatricula { get; set; }
    public string Imagem { get; set; }
    public bool PermiteApostilas { get; set; }
    public bool PermitePodcasts { get; set; }
    public bool PermiteProvasEspecialidade { get; set; }
    public bool PermiteSimulados { get; set; }
    public bool PermiteProvasHospital { get; set; }
    public ICollection<AlunoPlano> AlunoPlanos { get; set; }
}