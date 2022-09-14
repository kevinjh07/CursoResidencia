using CursoResidencia.Application.Exceptions;
using CursoResidencia.Application.UpdateProfessor;
using CursoResidencia.Domain.Context;

namespace CursoResidencia.Application.UpdateCurso;

public class UpdateProfessorHandler : IRequestHandler<UpdateProfessorCommand>
{
    private readonly ApplicationContext _context;

    public UpdateProfessorHandler(ApplicationContext context)
    {
        _context = context;
    }

    public Task<Unit> Handle(UpdateProfessorCommand request, CancellationToken cancellationToken)
    {
        var professor = _context.Professores
            .SingleOrDefault(c => c.Id == request.Id);

        if (professor == null)
        {
            throw new NotFoundException();
        }

        ValidarProfessor(request);

        _context.Entry(professor).CurrentValues
            .SetValues(new Professor(professor.Id, request.Nome, request.Email, professor.DataCadastro, request.Situacao, professor.ProfessorCursos));
        _context.SaveChanges();

        return Task.FromResult(Unit.Value);
    }

    private void ValidarProfessor(UpdateProfessorCommand professor)
    {
        var professorExiste = _context.Professores.Any(m => m.Email.Trim().ToUpper().Equals(professor.Email.Trim().ToUpper()));
        if (professorExiste)
        {
            throw new UnprocessableEntityException("Já existe um professor cadastrado com este email!");
        }
    }
}
