namespace CursoResidencia.Domain.Models;

public class Aula
{
    public int Id { get; set; }
    public int ModuloId { get; set; }
    public Modulo Modulo { get; set; }
    public int ProfessorId { get; set; }
    public Professor Professor { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string CodigoVimeo { get; set; }
    public Situacao Situacao { get; set; }
    public int Ordem { get; set; }
    public int OrdemTrial { get; set; }
    public ICollection<VisualizacaoAula> VisualizacaoAulas { get; set; }
    public ICollection<CursoAula> CursoAulas { get; set; }
}