using CursoResidencia.Application.Common.Mappings;

namespace CursoResidencia.Application.CreateCurso;

public class CreateCursoResult : IMapFrom<CreateCursoResponse>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public Situacao Situacao { get; set; }

    public CreateCursoResult(Curso curso)
    {
        Id = curso.Id;
        Nome = curso.Nome;
        DataInicio = curso.DataInicio;
        DataFim = curso.DataFim;
        Situacao = curso.Situacao;
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
            .ForMember(c => c.DataFim, opt => opt.MapFrom(c => c.DataFim))
            .ForMember(c => c.Situacao, opt => opt.MapFrom(c => c.Situacao));
    }
}
