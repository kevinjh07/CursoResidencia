using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Context;

namespace CursoResidencia.Application.CreateAula;

public class CreateAulaHandler : IRequestHandler<CreateAulaCommand, CreateAulaResult>
{
    private readonly ApplicationContext _context;

    public CreateAulaHandler(ApplicationContext context)
    {
        _context = context;
    }

    public Task<CreateAulaResult> Handle(CreateAulaCommand request, CancellationToken cancellationToken)
    {
        var result = Salvar(request);
        return Task.FromResult(result);
    }

    private CreateAulaResult Salvar(CreateAulaCommand request)
    {
        ValidarAula(request.Nome);
        ValidarModulo(request.ModuloId);

        var aula = new Aula(request.ModuloId, request.Nome, request.Descricao, request.LinkVideo);

        _context.Aulas.Add(aula);
        _context.SaveChanges();

        return new CreateAulaResult(aula);
    }

    private void ValidarAula(string nome)
    {
        var aulaExiste = _context.Aulas.Any(c => c.Nome.Trim().ToUpper().Equals(nome.Trim().ToUpper()));
        if (aulaExiste)
            throw new UnprocessableEntityException("Já existe uma aula cadastrada com este nome");
    }

    private void ValidarModulo(int moduloId)
    {
        var moduloNaoExiste = !_context.Modulos.Any(m => m.Id == moduloId);
        if (moduloNaoExiste)
            throw new UnprocessableEntityException("Módulo não encontrado");
    }
}
