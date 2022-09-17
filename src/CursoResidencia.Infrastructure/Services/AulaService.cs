using CursoResidencia.Domain.Context;
using CursoResidencia.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace CursoResidencia.Infrastructure.Services;

public class AulaService : IAulaService
{
    private readonly ApplicationContext _context;

    public AulaService(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Aula> GetAll(int cursoId)
    {
        return _context.Aulas
            .Where(a => a.Modulo.CursoId == cursoId)
            .ToList();
    }

    public IEnumerable<Aula> GetAllAvailable()
    {
        return _context.Aulas
            .Where(a => a.Situacao == Situacao.Ativo)
            .ToList();
    }

    public Aula? GetById(int id)
    {
        return _context.Aulas
            .SingleOrDefault(a => a.Id == id);
    }
}
