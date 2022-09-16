namespace CursoResidencia.Domain.Interfaces.Services;

public interface ICursoService
{
    IEnumerable<Curso> GetAll();
    Curso GetById(int id);
}
