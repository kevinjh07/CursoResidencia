using CursoResidencia.Domain.Context;
using CursoResidencia.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace CursoResidencia.Infrastructure.Services;

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
            .Include(p => p.ProfessorCursos)
            .Select(p => new Professor()
            {
                Id = p.Id,
                Nome = p.Nome,
                Email = p.Email,
                Situacao = p.Situacao,
                DataCadastro = p.DataCadastro,
                ProfessorCursos = p.ProfessorCursos
                    .Select(pc => new ProfessorCurso(pc.Curso))
                    .ToList()
            })
            .SingleOrDefault(p => p.Id == id);
    }

    public IEnumerable<Professor> GetAll()
    {
        List<Professor> professors = _context.Professores
                    .Include(p => p.ProfessorCursos)
                    .Select(p => new Professor()
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Email = p.Email,
                        Situacao = p.Situacao,
                        DataCadastro = p.DataCadastro,
                        ProfessorCursos = p.ProfessorCursos
                            .Select(pc => new ProfessorCurso(pc.Curso))
                            .ToList()
                    })
                    .ToList();
        return professors;
    }
}
