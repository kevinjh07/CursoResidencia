namespace CursoResidencia.Domain.Models;

public class Modulo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Situacao Situacao { get; set; }
    public int SiteId { get; set; }
    public string Imagem { get; set; }
    public ICollection<Aula> Aulas { get; set; }
    public ICollection<Simulado> Simulados { get; set; }
    public Situacao Ativo { get; set; }
    public ICollection<Podcast> Podcasts { get; set; }
}