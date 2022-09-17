using CursoResidencia.Domain.Context;
using CursoResidencia.Domain.Interfaces.Services;

namespace CursoResidencia.Infrastructure.Services;

public class ProfessorService : IProfessorService
{
    private readonly ApplicationContext _context;

    public ProfessorService(ApplicationContext context)
    {
        _context = context;
    }

    public Professor? Get(int id)
    {
        return _context.Professores
            .Select(p => new Professor()
            {
                Id = p.Id,
                Nome = p.Nome,
                Email = p.Email,
                Situacao = p.Situacao,
                DataCadastro = p.DataCadastro
            })
            .SingleOrDefault(p => p.Id == id);
    }

    public IEnumerable<Professor> GetAll()
    {
        return _context.Professores
                    .Select(p => new Professor()
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Email = p.Email,
                        Situacao = p.Situacao,
                        DataCadastro = p.DataCadastro
                    })
                    .ToList();
    }
}
