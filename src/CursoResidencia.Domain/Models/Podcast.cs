namespace CursoResidencia.Domain.Models;

public class Podcast
{
    public int Id { get; set; }
    public int ModuloId { get; set; }
    public Modulo Modulo { get; set; }
    public string Titulo { get; set; }
    public string Arquivo { get; set; }
    public Situacao Situacao { get; set; }
}