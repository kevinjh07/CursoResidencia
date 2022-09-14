using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Context;

namespace CursoResidencia.Application.CreateProfessor;

public class CreateProfessorHandler : IRequestHandler<CreateProfessorCommand, CreateProfessorResult>
{
    private readonly ApplicationContext _context;

    public CreateProfessorHandler(ApplicationContext context)
    {
        _context = context;
    }

    public Task<CreateProfessorResult> Handle(CreateProfessorCommand request, CancellationToken cancellationToken)
    {
        ValidarProfessor(request);

        var professor = new Professor(request.Nome, request.Email, request.ProfessorCursos.Select(pc => pc.CursoId));
        _context.Professores.Add(professor);
        _context.SaveChanges();

        return Task.FromResult(new CreateProfessorResult(professor));
    }

    private void ValidarProfessor(CreateProfessorCommand professor)
    {
        var professorExiste = _context.Professores.Any(m => m.Email.Trim().ToUpper().Equals(professor.Email.Trim().ToUpper()));
        if (professorExiste)
        {
            throw new UnprocessableEntityException("Já existe um professor cadastrado com este email!");
        }
    }
}
