namespace CursoResidencia.Application.UpdateCurso;

public class UpdateCursoValidator : AbstractValidator<UpdateCursoCommand>
{
    public UpdateCursoValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty();

        RuleFor(x => x.DataInicio)
            .NotNull();

        RuleFor(x => x.DataFim)
            .NotNull()
            .GreaterThanOrEqualTo(x => x.DataInicio);

        RuleFor(x => x.Situacao)
            .IsInEnum()
            .NotNull();
    }
}
