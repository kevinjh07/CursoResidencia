using CursoResidencia.Application.Common.Mappings;

namespace CursoResidencia.Application.CreateModulo;

public class CreateModuloResult : IMapFrom<CreateModuloResponse>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Situacao Situacao { get; set; }
    public int CursoId { get; set; }
    public DateTime DataCadastro { get; set; }

    public CreateModuloResult(Modulo modulo)
    {
        Id = modulo.Id;
        Nome = modulo.Nome;
        Situacao = modulo.Situacao;
        CursoId = modulo.CursoId;
        DataCadastro = modulo.DataCadastro;
    }

    public CreateModuloResult()
    {

    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateModuloResponse, CreateModuloResult>()
            .ForMember(m => m.Id, opt => opt.MapFrom(m => m.Id))
            .ForMember(m => m.Nome, opt => opt.MapFrom(m => m.Nome))
            .ForMember(m => m.Situacao, opt => opt.MapFrom(m => m.Situacao))
            .ForMember(m => m.CursoId, opt => opt.MapFrom(m => m.CursoId));
    }
}
