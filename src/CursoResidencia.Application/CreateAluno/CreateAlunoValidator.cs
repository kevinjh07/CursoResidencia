namespace CursoResidencia.Application.CreateAluno;

public class CreateAlunoValidator : AbstractValidator<CreateAlunoCommand>
{
    public CreateAlunoValidator()
    {
        RuleFor(x => x.NomeCompleto)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Cpf)
            .NotEmpty()
            .MaximumLength(11);

        RuleFor(x => x.Crm)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Senha)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(20);

        RuleFor(x => x.ConfirmacaoSenha)
            .NotEmpty()
            .MinimumLength(6)
            .MaximumLength(20)
            .Equal(x => x.Senha)
            .WithMessage("Confirmação de senha deve ser igual à senha");

    }
}
