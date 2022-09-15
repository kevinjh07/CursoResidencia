namespace CursoResidencia.Application.CreateAula;

public class CreateAulaValidator : AbstractValidator<CreateAulaCommand>
{
    public CreateAulaValidator()
    {
        RuleFor(x => x.Nome)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(x => x.ModuloId)
            .NotNull();

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .MaximumLength(500);

        RuleFor(x => x.LinkVideo)
            .NotEmpty()
            .MaximumLength(500);
    }
}
