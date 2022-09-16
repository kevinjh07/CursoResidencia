namespace CursoResidencia.Domain.Interfaces.Services;

public interface IModuloRepository
{
    IEnumerable<Modulo> GetAll();
    Modulo GetById(int id);
}
