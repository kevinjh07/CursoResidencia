using CursoResidencia.Application.Common.Mappings;

namespace CursoResidencia.Application.CreateProfessor;

public class CreateProfessorResult : IMapFrom<CreateProfessorResponse>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public Situacao Situacao { get; set; }
    public ICollection<ProfessorCurso> ProfessorCursos { get; set; }

    public CreateProfessorResult(Professor professor)
    {
        Id = professor.Id;
        Nome = professor.Nome;
        Email = professor.Email;
        Situacao = professor.Situacao;
        ProfessorCursos = professor.ProfessorCursos;
    }

    public CreateProfessorResult()
    {

    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProfessorResponse, CreateProfessorResult>()
            .ForMember(m => m.Id, opt => opt.MapFrom(m => m.Id))
            .ForMember(m => m.Nome, opt => opt.MapFrom(m => m.Nome))
            .ForMember(m => m.Email, opt => opt.MapFrom(m => m.Email))
            .ForMember(m => m.Situacao, opt => opt.MapFrom(m => m.Situacao))
            .ForMember(m => m.ProfessorCursos, opt => opt.MapFrom(m => m.ProfessorCursos));
    }
}
