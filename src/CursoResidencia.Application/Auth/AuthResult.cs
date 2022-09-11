using CursoResidencia.Application.Common.Mappings;

namespace CursoResidencia.Application.Auth;

public class AuthResult : IMapFrom<AuthResponse>
{
    public string Token { get; set; }
    public DateTimeOffset Expiration { get; set; }
    public string RefreshToken { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<AuthResponse, AuthResult>()
            .ForMember(d => d.Token, opt => opt.MapFrom(s => s.Token))
            .ForMember(d => d.Expiration, opt => opt.MapFrom(s => s.Expiration))
            .ForMember(d => d.RefreshToken, opt => opt.MapFrom(s => s.RefreshToken));
    }
}