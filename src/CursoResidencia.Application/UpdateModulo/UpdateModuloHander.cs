using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Context;

namespace CursoResidencia.Application.UpdateModulo;

public class UpdateModuloHander : IRequestHandler<UpdateModuloCommand>
{
    private readonly ApplicationContext _context;

    public UpdateModuloHander(ApplicationContext context)
    {
        _context = context;
    }

    public Task<Unit> Handle(UpdateModuloCommand request, CancellationToken cancellationToken)
    {
        ValidarModulo(request);
        ValidarCurso(request.CursoId);

        var modulo = _context.Modulos
                    .SingleOrDefault(c => c.Id == request.Id);

        if (modulo == null)
        {
            throw new NotFoundException();
        }

        _context.Entry(modulo).CurrentValues
            .SetValues(new Modulo(modulo.Id, request.Nome, modulo.DataCadastro, request.Situacao, request.CursoId));

        _context.SaveChanges();

        return Task.FromResult(Unit.Value);
    }

    private void ValidarModulo(UpdateModuloCommand request)
    {
        var moduloExiste = _context.Cursos.Any(c => c.Nome.Trim().ToUpper().Equals(request.Nome.Trim().ToUpper()) && c.Id != request.Id);
        if (moduloExiste)
        {
            throw new UnprocessableEntityException("Já existe um módulo cadastrado com este nome");
        }
    }

    private void ValidarCurso(int cursoId)
    {
        var cursoExiste = _context.Cursos.Any(c => c.Id == cursoId);
        if (!cursoExiste)
        {
            throw new UnprocessableEntityException("Curso não encontrado!");
        }
    }
}
