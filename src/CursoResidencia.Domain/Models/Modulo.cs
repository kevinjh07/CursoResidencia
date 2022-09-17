namespace CursoResidencia.Domain.Models;

public class Modulo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Situacao Situacao { get; set; }
    public DateTime DataCadastro { get; set; }
    public int CursoId { get; set; }
    public Curso Curso { get; set; }
    public ICollection<Aula> Aulas { get; set; }

    public Modulo(string nome, int cursoId)
    {
        Nome = nome;
        CursoId = cursoId;
        Situacao = Situacao.Ativo;
        DataCadastro = DateTime.Now;
    }

    public Modulo(int id, string nome, DateTime dataCadastro, Situacao situacao, int cursoId)
    {
        Id = id;
        Nome = nome;
        DataCadastro = dataCadastro;
        Situacao = situacao;
        CursoId = cursoId;
    }

    public Modulo()
    {

    }
}
