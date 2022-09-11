using CursoResidencia.Domain.Context;

namespace CursoResidencia.Domain.Repository;

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
}
