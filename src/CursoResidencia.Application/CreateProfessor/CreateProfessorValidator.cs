namespace CursoResidencia.Application.CreateProfessor;

public class CreateProfessorValidator : AbstractValidator<CreateProfessorCommand>
{
    public CreateProfessorValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotNull()
            .EmailAddress();
    }
}
