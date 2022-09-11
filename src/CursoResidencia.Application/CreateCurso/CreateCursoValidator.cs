namespace CursoResidencia.Application.CreateCurso;

public class CreateCursoValidator : AbstractValidator<CreateCursoCommand>
{
    public CreateCursoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty();

        RuleFor(x => x.DataInicio)
            .NotNull();

        RuleFor(x => x.DataFim)
            .NotNull()
            .GreaterThanOrEqualTo(x => x.DataInicio);
    }
}
