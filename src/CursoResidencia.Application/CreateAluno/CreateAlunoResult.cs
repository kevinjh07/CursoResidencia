using CursoResidencia.Application.Common.Mappings;

namespace CursoResidencia.Application.CreateAluno;

public class CreateAlunoResult : IMapFrom<CreateAlunoResponse>
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Email { get; set; }
    public string Cpf { get; set; }
    public string Crm { get; set; }

    public CreateAlunoResult(Aluno aluno)
    {
        Id = aluno.Id;
        NomeCompleto = aluno.NomeCompleto;
        Email = aluno.Email;
        Cpf = aluno.Cpf;
        Crm = aluno.Crm;
    }

    public CreateAlunoResult()
    {

    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateAlunoResponse, CreateAlunoResult>()
            .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.NomeCompleto, opt => opt.MapFrom(s => s.NomeCompleto))
            .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
            .ForMember(d => d.Cpf, opt => opt.MapFrom(s => s.Cpf))
            .ForMember(d => d.Crm, opt => opt.MapFrom(s => s.Crm));
    }
}
