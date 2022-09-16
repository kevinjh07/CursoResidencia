namespace CursoResidencia.Application.CreateAluno;

public class CreateAlunoCommand : IRequest<CreateAlunoResult>
{
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public string Crm { get; set; }
    public string Senha { get; set; }
    public string ConfirmacaoSenha { get; set; }
}
