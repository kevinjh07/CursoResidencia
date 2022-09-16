using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Context;
using CursoResidencia.Domain.Interfaces.Services;

namespace CursoResidencia.Application.UpdateAula;

public class UpdateAulaHandler : IRequestHandler<UpdateAulaCommand>
{
    private readonly IAulaService _aulaService;
    private readonly IModuloService _moduloService;
    private readonly ApplicationContext _context;

    public UpdateAulaHandler(IAulaService aulaService, IModuloService moduloService, ApplicationContext context)
    {
        _aulaService = aulaService;
        _moduloService = moduloService;
        _context = context;
    }

    public Task<Unit> Handle(UpdateAulaCommand request, CancellationToken cancellationToken)
    {
        var aula = _aulaService.GetById(request.Id);
        if (aula == null)
            throw new NotFoundException();

        var modulo = _moduloService.GetById(request.ModuloId);
        if (modulo == null)
            throw new UnprocessableEntityException("Módulo não econtrado");

        _context.Entry(aula)
            .CurrentValues
            .SetValues(new Aula(aula.Id,
                request.ModuloId,
                request.Nome,
                request.Descricao,
                request.LinkVideo,
        request.Situacao));
        _context.SaveChanges();

        return Task.FromResult(Unit.Value);
    }
}
