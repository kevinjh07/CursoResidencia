using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Context;

namespace CursoResidencia.Application.UpdateCurso;

public class UpdateCursoHandler : IRequestHandler<UpdateCursoCommand>
{
    private readonly ApplicationContext _context;

    public UpdateCursoHandler(ApplicationContext context)
    {
        _context = context;
    }

    public Task<Unit> Handle(UpdateCursoCommand request, CancellationToken cancellationToken)
    {
        var curso = _context.Cursos
                    .SingleOrDefault(c => c.Id == request.Id);

        if (curso == null)
        {
            throw new NotFoundException();
        }

        if (CursoExiste(request.Id, curso.Nome))
        {
            throw new UnprocessableEntityException("Já existe um curso cadastrado com este nome.");
        }

        _context.Entry(curso).CurrentValues
            .SetValues(new Curso(curso.Id, request.Nome, curso.DataCadastro, request.DataInicio, request.DataFim, request.Situacao));

        _context.SaveChanges();

        return Task.FromResult(Unit.Value);
    }

    private bool CursoExiste(int id, string nome)
    {
        return _context.Cursos.Any(c => c.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper()) && c.Id != id);
    }
}
