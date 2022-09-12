namespace CursoResidencia.Application.CreateModulo;

public class CreateModuloValidator : AbstractValidator<CreateModuloCommand>
{
    public CreateModuloValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty();

        RuleFor(x => x.CursoId)
            .NotEmpty();
    }
}
