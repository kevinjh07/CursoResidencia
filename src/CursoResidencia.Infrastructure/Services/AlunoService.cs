using CursoResidencia.Domain.Context;
using CursoResidencia.Domain.Interfaces.Services;

namespace CursoResidencia.Infrastructure.Services;

public class AlunoService : IAlunoService
{
    private readonly ApplicationContext _context;

    public AlunoService(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Aluno> GetAll()
    {
        return _context.Alunos.ToList();
    }

    public Aluno? GetById(int id)
    {
        return _context.Alunos.SingleOrDefault(a => a.Id == id);
    }
}
