namespace CursoResidencia.Application.CreateAluno;

public class CreateAlunoResponse
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public string Crm { get; set; }
    public DateTime DataDeCadastro { get; set; }
}
