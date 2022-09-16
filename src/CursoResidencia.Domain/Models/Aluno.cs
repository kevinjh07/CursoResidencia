namespace CursoResidencia.Domain.Models;

public class Aluno
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public string Crm { get; set; }
    public DateTime DataDeCadastro { get; set; }
    public int UsuarioId { get; set; }
    public ApplicationUser Usuario { get; set; }

    public Aluno(string nomeCompleto, string email, string cpf, string crm, int usuarioId)
    {
        NomeCompleto = nomeCompleto;
        Email = email;
        Cpf = cpf;
        Crm = crm;
        DataDeCadastro = DateTime.Now;
        UsuarioId = usuarioId;
    }

    public Aluno()
    {

    }
}
