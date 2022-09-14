using CursoResidencia.Domain.Context;

namespace CursoResidencia.Domain.Repository;

public class ProfessorRepository : IProfessorRepository
{
    private readonly ApplicationContext _context;

    public ProfessorRepository(ApplicationContext context)
    {
        _context = context;
    }

    public Professor? Get(int id)
    {
        return _context.Professores
            .SingleOrDefault(p => p.Id == id);
    }

    public IEnumerable<Professor> GetAll()
    {
        return _context.Professores.ToList();
    }
}
