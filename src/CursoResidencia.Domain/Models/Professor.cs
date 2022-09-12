namespace CursoResidencia.Domain.Models;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public Situacao Situacao { get; set; }
    public ICollection<ProfessorCurso> ProfessorCursos { get; set; }

    public Professor(string nome, string email)
    {
        Nome = nome;
        Email = email;
        Situacao = Situacao.Ativo;
    }

    public Professor()
    {

    }
}