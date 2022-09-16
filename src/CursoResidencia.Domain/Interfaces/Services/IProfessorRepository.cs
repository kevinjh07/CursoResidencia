namespace CursoResidencia.Domain.Interfaces.Services;

public interface IProfessorRepository
{
    Professor? Get(int id);
    IEnumerable<Professor> GetAll();
}
