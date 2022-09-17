namespace CursoResidencia.Application.CreateCurso;

public class CreateCursoValidator : AbstractValidator<CreateCursoCommand>
{
    public CreateCursoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.ProfessorId)
            .NotNull();
    }
}
