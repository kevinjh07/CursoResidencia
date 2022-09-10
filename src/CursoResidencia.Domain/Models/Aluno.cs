namespace CursoResidencia.Domain.Models;

public class Aluno
{
    public int Id { get; set; }
    public DateTime DataDeCadastro { get; set; }
    public string NomeCompleto { get; set; }
    public string Cep { get; set; }
    public string Endereco { get; set; }
    public string Complemento { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public Uf Estado { get; set; }
    public int InstituicaoId { get; set; }
    public int AnoFormatura { get; set; }
    public string Cpf { get; set; }
    public string Imagem { get; set; }
    public int SiteId { get; set; }
    public bool? CadastroCompleto { get; set; }
    public string Crm { get; set; }
    public int UsuarioId { get; set; }
    public ApplicationUser Usuario { get; set; }
    public string DeviceId { get; set; }
    public ICollection<VisualizacaoAula> VisualizacaoAula { get; set; }
    public ICollection<Simulado> Simulados { get; set; }
    public ICollection<AlunoPlano> AlunoPlanos { get; set; }
    public ICollection<AlunoPodcast> AlunoPodcasts { get; set; }
}