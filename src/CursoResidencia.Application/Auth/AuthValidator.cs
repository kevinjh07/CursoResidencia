namespace CursoResidencia.Application.Auth;

public class AuthValidator : AbstractValidator<AuthCommand>
{
    public AuthValidator()
    {
        RuleFor(command => command.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(command => command.Senha)
            .NotEmpty();
    }
}
