using CursoResidencia.Domain.Context;
using CursoResidencia.Domain.Interfaces.Services;

namespace CursoResidencia.Infrastructure.Services;

public class ModuloService : IModuloService
{
    private readonly ApplicationContext _context;

    public ModuloService(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Modulo> GetAll()
    {
        return _context.Modulos.ToList();
    }

    public Modulo GetById(int id)
    {
        return _context.Modulos.SingleOrDefault(m => m.Id == id);
    }
}
