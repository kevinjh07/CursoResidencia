namespace CursoResidencia.Domain.Interfaces.Services;

public interface IAulaService
{
    IEnumerable<Aula> GetAll();
    IEnumerable<Aula> GetAllAvailable();
    Aula? GetById(int id);
}
