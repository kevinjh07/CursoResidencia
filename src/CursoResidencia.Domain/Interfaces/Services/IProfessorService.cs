namespace CursoResidencia.Domain.Interfaces.Services;

public interface IProfessorService
{
    Professor? Get(int id);
    IEnumerable<Professor> GetAll();
}
