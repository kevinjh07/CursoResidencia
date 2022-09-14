namespace CursoResidencia.Domain.Repository;

public interface IProfessorRepository
{
    Professor? Get(int id);
    IEnumerable<Professor> GetAll();
}
