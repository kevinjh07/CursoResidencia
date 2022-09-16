namespace CursoResidencia.Domain.Interfaces.Services;

public interface IAulaService
{
    IEnumerable<Aula> GetAll();
    Aula? GetById(int id);
}
