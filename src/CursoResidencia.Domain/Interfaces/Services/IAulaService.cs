namespace CursoResidencia.Domain.Interfaces.Services;

public interface IAulaService
{
    IEnumerable<Aula> GetAll(int cursoId);
    IEnumerable<Aula> GetAllAvailable();
    Aula? GetById(int id);
}
