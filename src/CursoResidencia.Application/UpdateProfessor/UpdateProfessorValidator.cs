namespace CursoResidencia.Application.UpdateProfessor;

public class UpdateProfessorValidator : AbstractValidator<UpdateProfessorCommand>
{
	public UpdateProfessorValidator()
	{
		RuleFor(x => x.Nome)
			.NotEmpty();

		RuleFor(x => x.Email)
			.NotEmpty()
			.EmailAddress();

		RuleFor(x => x.Situacao)
			.IsInEnum()
			.NotNull();
	}
}
