namespace CursoResidencia.Domain.Interfaces.Services;

public interface IModuloService
{
    IEnumerable<Modulo> GetAll();
    Modulo GetById(int id);
}
