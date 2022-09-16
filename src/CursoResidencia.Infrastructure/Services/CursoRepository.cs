using CursoResidencia.Domain.Context;
using CursoResidencia.Domain.Interfaces.Services;

namespace CursoResidencia.Infrastructure.Services;

public class CursoRepository : ICursoRepository
{
    private readonly ApplicationContext _context;

    public CursoRepository(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Curso> GetAll()
    {
        return _context.Cursos.ToList();
    }

    public Curso GetById(int id)
    {
        return _context.Cursos.SingleOrDefault(c => c.Id == id);
    }
}