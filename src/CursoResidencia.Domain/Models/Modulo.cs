namespace CursoResidencia.Domain.Models;

public class Modulo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Situacao Situacao { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CursoId { get; set; }
    public Curso Curso { get; set; }
    public ICollection<Simulado> Simulados { get; set; }
    public ICollection<Podcast> Podcasts { get; set; }
    public ICollection<Aula> Aulas { get; internal set; }

    public Modulo(string nome, int cursoId)
    {
        Nome = nome;
        CursoId = cursoId;
        Situacao = Situacao.Ativo;
        DataCadastro = DateTime.Now;
    }
}