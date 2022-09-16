namespace CursoResidencia.Domain.Interfaces.Services;

public interface IAlunoService
{
    IEnumerable<Aluno> GetAll();
    Aluno? GetById(int id);
}
