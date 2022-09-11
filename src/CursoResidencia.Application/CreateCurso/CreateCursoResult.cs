using CursoResidencia.Application.Common.Mappings;

namespace CursoResidencia.Application.CreateCurso;

public class CreateCursoResult : IMapFrom<CreateCursoResponse>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }

    public CreateCursoResult(int id, string nome, DateTime dataInicio, DateTime dataFim)
    {
        Id = id;
        Nome = nome;
        DataInicio = dataInicio;
        DataFim = dataFim;
    }

    public CreateCursoResult()
    {

    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCursoResponse, CreateCursoResult>()
            .ForMember(c => c.Id, opt => opt.MapFrom(c => c.Id))
            .ForMember(c => c.Nome, opt => opt.MapFrom(c => c.Nome))
            .ForMember(c => c.DataInicio, opt => opt.MapFrom(c => c.DataInicio))
            .ForMember(c => c.DataFim, opt => opt.MapFrom(c => c.DataFim));
    }
}
