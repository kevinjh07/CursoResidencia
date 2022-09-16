namespace CursoResidencia.Domain.Interfaces.Services;

public interface ICursoRepository
{
    IEnumerable<Curso> GetAll();
    Curso GetById(int id);
}