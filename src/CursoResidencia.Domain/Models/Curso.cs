namespace CursoResidencia.Domain.Models;

public class Curso
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataCadastro { get; set; }
    public ICollection<CursoAula> CursoAulas { get; set; }
    public ICollection<ProfessorCurso> ProfessorCursos { get; set; }
    public ICollection<Simulado> Simulados { get; set; }
    public ICollection<Modulo> Modulos { get; set; }
    public Situacao Situacao { get; set; }

    public Curso(string nome)
    {
        Nome = nome;
        DataCadastro = DateTime.Now;
        Situacao = Situacao.Ativo;
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
