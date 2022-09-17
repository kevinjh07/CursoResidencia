using CursoResidencia.Application.Common.Mappings;

namespace CursoResidencia.Application.CreateCurso;

public class CreateCursoResult : IMapFrom<CreateCursoResponse>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Situacao Situacao { get; set; }
    public int ProfessorId { get; set; }

    public CreateCursoResult(Curso curso)
    {
        Id = curso.Id;
        Nome = curso.Nome;
        Situacao = curso.Situacao;
        ProfessorId = curso.ProfessorId;
    }

    public CreateCursoResult()
    {

    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateCursoResponse, CreateCursoResult>()
            .ForMember(c => c.Id, opt => opt.MapFrom(c => c.Id))
            .ForMember(c => c.Nome, opt => opt.MapFrom(c => c.Nome))
            .ForMember(c => c.Situacao, opt => opt.MapFrom(c => c.Situacao))
            .ForMember(c => c.ProfessorId, opt => opt.MapFrom(c => c.ProfessorId));
    }
}
