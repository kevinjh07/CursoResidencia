namespace CursoResidencia.Application.CreateModulo;

public class CreateModuloResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Situacao Situacao { get; set; }
    public int CursoId { get; set; }
}
