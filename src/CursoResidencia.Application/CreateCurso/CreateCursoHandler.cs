using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Context;

namespace CursoResidencia.Application.CreateCurso;

public class CreateCursoHandler : IRequestHandler<CreateCursoCommand, CreateCursoResult>
{
    private readonly ApplicationContext _context;

    public CreateCursoHandler(ApplicationContext context)
    {
        _context = context;
    }

    public Task<CreateCursoResult> Handle(CreateCursoCommand request, CancellationToken cancellationToken)
    {
        var result = Salvar(request);
        return Task.FromResult(result);
    }

    private CreateCursoResult Salvar(CreateCursoCommand request)
    {
        if (CursoExiste(request.Nome))
            throw new UnprocessableEntityException("Já existe um curso cadastrado com este nome");

        var curso = new Curso(request.Nome);

        _context.Cursos.Add(curso);
        _context.SaveChanges();

        return new CreateCursoResult(curso);
    }

    private bool CursoExiste(string nome)
    {
        return _context.Cursos.Any(c => c.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper()));
    }
}
