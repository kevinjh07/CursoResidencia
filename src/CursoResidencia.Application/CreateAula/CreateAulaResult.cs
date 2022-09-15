using CursoResidencia.Application.Common.Mappings;

namespace CursoResidencia.Application.CreateAula;

public class CreateAulaResult : IMapFrom<CreateAulaResponse>
{
    public int Id { get; set; }
    public int ModuloId { get; set; }
    public Modulo Modulo { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string LinkVideo { get; set; }
    public Situacao Situacao { get; set; }
    public DateTime DataCadastro { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateAulaResponse, CreateAulaResult>()
            .ForMember(a => a.Id, opt => opt.MapFrom(a => a.Id))
            .ForMember(a => a.Nome, opt => opt.MapFrom(a => a.Nome))
            .ForMember(a => a.ModuloId, opt => opt.MapFrom(a => a.ModuloId))
            .ForMember(a => a.DataCadastro, opt => opt.MapFrom(a => a.DataCadastro))
            .ForMember(a => a.Descricao, opt => opt.MapFrom(a => a.Descricao))
            .ForMember(a => a.LinkVideo, opt => opt.MapFrom(a => a.LinkVideo))
            .ForMember(a => a.Situacao, opt => opt.MapFrom(a => a.Situacao));
    }

    public CreateAulaResult(Aula aula)
    {
        Id = aula.Id;
        ModuloId = aula.ModuloId;
        Nome = aula.Nome;
        Descricao = aula.Descricao;
        LinkVideo = aula.LinkVideo;
        Situacao = aula.Situacao;
        DataCadastro = aula.DataCadastro;
    }

    public CreateAulaResult()
    {

    }
}
