namespace CursoResidencia.Domain.Models;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public Situacao Situacao { get; set; }
    public DateTime DataCadastro { get; set; }
    public IEnumerable<Curso> Cursos { get; internal set; }

    public Professor(string nome, string email)
    {
        Nome = nome;
        Email = email;
        Situacao = Situacao.Ativo;
        DataCadastro = DateTime.Now;
    }

    public Professor()
    {

    }

    public Professor(int id, string nome, string email, DateTime dataCadastro, Situacao situacao)
    {
        Id = id;
        Nome = nome;
        Email = email;
        DataCadastro = dataCadastro;
        Situacao = situacao;
    }
}
