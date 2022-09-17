namespace CursoResidencia.Application.CreateCurso;

public class CreateCursoValidator : AbstractValidator<CreateCursoCommand>
{
    public CreateCursoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .MaximumLength(200);
    }
}
