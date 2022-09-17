using CursoResidencia.Domain.Context;
using CursoResidencia.Domain.Interfaces.Services;
using CursoResidencia.Domain.Models.Dto;

namespace CursoResidencia.Infrastructure.Services;

public class CursoService : ICursoService
{
    private readonly ApplicationContext _context;

    public CursoService(ApplicationContext context)
    {
        _context = context;
    }

    public IEnumerable<Curso> GetAll()
    {
        return _context.Cursos.ToList();
    }

    public IEnumerable<CursoDto> GetAulas(int id)
    {
        return _context.Cursos
            .Where(c => c.Situacao == Situacao.Ativo)
            .Select(c => new CursoDto()
            {
                Id = c.Id,
                Nome = c.Nome,
                NomeProfessor = c.Professor.Nome,
                Aulas = _context.Aulas
                    .Where(a => a.Situacao == Situacao.Ativo && a.Modulo.CursoId == c.Id)
                    .Select(a => new AulaDto()
                    {
                        Id = a.Id,
                        Nome = a.Nome,
                        Descricao = a.Descricao,
                        NomeModulo = a.Modulo.Nome,
                        LinkVideo = a.LinkVideo
                    })
                    .ToList()
            })
            .ToList();
    }

    public Curso? GetById(int id)
    {
        return _context.Cursos.SingleOrDefault(c => c.Id == id);
    }

    public IEnumerable<CursoDto> GetDisponiveis()
    {
        return _context.Cursos
            .Where(c => c.Situacao == Situacao.Ativo)
            .Select(c => new CursoDto()
            {
                Id = c.Id,
                Nome = c.Nome,
                NomeProfessor = c.Professor.Nome
            });
    }
}
