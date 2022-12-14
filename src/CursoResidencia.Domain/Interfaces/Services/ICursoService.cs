using CursoResidencia.Domain.Models.Dto;

namespace CursoResidencia.Domain.Interfaces.Services;

public interface ICursoService
{
    IEnumerable<Curso> GetAll();
    CursoDto? GetAulas(int id);
    Curso? GetById(int id);
    IEnumerable<CursoDto> GetDisponiveis();
}
