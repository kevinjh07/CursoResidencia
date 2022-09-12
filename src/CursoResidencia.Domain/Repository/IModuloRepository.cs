namespace CursoResidencia.Domain.Repository;

public interface IModuloRepository
{
    IEnumerable<Modulo> GetAll();
    Modulo GetById(int id);
}
