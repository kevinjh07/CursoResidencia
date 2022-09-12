namespace CursoResidencia.Application.UpdateModulo;

public class UpdateModuloValidator : AbstractValidator<UpdateModuloCommand>
{
    public UpdateModuloValidator()
    {
        RuleFor(x => x.Nome)
            .NotEmpty();

        RuleFor(x => x.Situacao)
            .IsInEnum()
            .NotNull();

        RuleFor(x => x.CursoId)
            .NotNull();
    }
}
