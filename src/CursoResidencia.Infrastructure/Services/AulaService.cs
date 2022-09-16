using CursoResidencia.Domain.Context;
using CursoResidencia.Domain.Interfaces.Services;

namespace CursoResidencia.Infrastructure.Services;

public class AulaService : IAulaService
{
    private readonly ApplicationContext _context;

    public AulaService(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Aula> GetAll()
    {
        return _context.Aulas.ToList();
    }

    public Aula? GetById(int id)
    {
        return _context.Aulas.SingleOrDefault(a => a.Id == id);
    }
}