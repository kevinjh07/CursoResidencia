using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Context;

namespace CursoResidencia.Application.CreateModulo;

public class CreateModuloHandler : IRequestHandler<CreateModuloCommand, CreateModuloResult>
{
    private readonly ApplicationContext _context;

    public CreateModuloHandler(ApplicationContext context)
    {
        _context = context;
    }

    public Task<CreateModuloResult> Handle(CreateModuloCommand request, CancellationToken cancellationToken)
    {
        ValidarModulo(request.Nome);
        ValidarCurso(request.CursoId);

        var modulo = new Modulo(request.Nome, request.CursoId);
        _context.Modulos.Add(modulo);
        _context.SaveChanges();

        return Task.FromResult(new CreateModuloResult(modulo));
    }

    private void ValidarModulo(string nome)
    {
        var moduloExiste = _context.Modulos.Any(m => m.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper()));
        if (moduloExiste)
        {
            throw new UnprocessableEntityException("Já existe um módulo cadastrado com este nome!");
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
