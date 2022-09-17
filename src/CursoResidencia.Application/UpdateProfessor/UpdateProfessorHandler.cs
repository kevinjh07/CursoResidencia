using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace CursoResidencia.Application.UpdateProfessor;

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

        _context.Entry(professor)
            .CurrentValues
            .SetValues(new Professor(professor.Id,
                request.Nome,
                request.Email,
                professor.DataCadastro,
                request.Situacao));
        _context.SaveChanges();

        return Task.FromResult(Unit.Value);
    }

    private void ValidarProfessor(UpdateProfessorCommand professor)
    {
        var professorExiste = _context.Professores.Any(p => p.Email.Trim().ToUpper().Equals(professor.Email.Trim().ToUpper()) && p.Id != professor.Id);
        if (professorExiste)
        {
            throw new UnprocessableEntityException("Já existe um professor cadastrado com este email!");
        }
    }
}
