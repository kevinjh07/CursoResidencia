namespace CursoResidencia.Domain.Models;

public class Curso
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataCadastro { get; set; }
    public ICollection<Modulo> Modulos { get; set; }
    public Situacao Situacao { get; set; }
    public int ProfessorId { get; set; }
    public Professor Professor { get; set; }

    public Curso(string nome, int professorId)
    {
        Nome = nome;
        DataCadastro = DateTime.Now;
        Situacao = Situacao.Ativo;
        ProfessorId = professorId;
    }

    public Curso(int id, string nome, DateTime dataCadastro, Situacao situacao)
    {
        Id = id;
        Nome = nome;
        DataCadastro = dataCadastro;
        Situacao = situacao;
    }

    public Curso()
    {

    }
}
