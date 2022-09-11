using CursoResidencia.Application.Exceptions;
using CursoResidencia.Domain.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CursoResidencia.Application.Auth;

public class AuthHandler : IRequestHandler<AuthCommand, AuthResult>
{
    private readonly ILogger<AuthHandler> _logger;
    private readonly IMapper _mapper;
    //private readonly IHelloWorldService _helloWorldService;
    private readonly UserManager<ApplicationUser> _userManager;
    //private readonly IOptions<AppSettings> _appSettings;
    private readonly ApplicationContext _context;

    public AuthHandler(ILogger<AuthHandler> logger,
                                    IMapper mapper/*,
                                    IHelloWorldService helloWorldService*/,
                                    UserManager<ApplicationUser> userManager,
                                    ApplicationContext context)
    {
        _logger = logger;
        _mapper = mapper;
        //_helloWorldService = helloWorldService;
        _userManager = userManager;
        _context = context;
    }

    public async Task<AuthResult> Handle(AuthCommand request, CancellationToken cancellationToken)
    {
        //var response = await _helloWorldService.Create(request.UserName, (int)request.Level);
        var response = await LoginAsync(request);

        return _mapper.Map<AuthResult>(response);
    }

    private async Task<AuthResponse> LoginAsync(AuthCommand request)
    {
        var user = GetUsuarioIdentity(request.Email);
        await ValidarLoginAsync(request, user);
        var loginResponse = await GetLoginResponse(user);

        user.UltimoLogin = DateTime.Now;
        _context.SaveChanges();

        return loginResponse;
    }

    private ApplicationUser GetUsuarioIdentity(string email)
    {
        var user = _userManager.Users
            .Include(u => u.Aluno)
            .SingleOrDefault(u => u.Email == email);

        //if (user == null)
        //{
        //    throw new NotFoundException("Usuário não encontrado!");
        //}

        return user;
    }

    private async Task ValidarLoginAsync(AuthCommand login, ApplicationUser user)
    {
        if (!await _userManager.CheckPasswordAsync(user, login.Senha))
        {
            throw new UnprocessableEntityException("Usuário ou senha inválidos!");
        }

        if (user.Situacao == Situacao.Inativo)
        {
            //throw new UnprocessableEntityException("Usuário inativo, entre em contato o administrador do sistema");
        }
    }

    private async Task<AuthResponse> GetLoginResponse(ApplicationUser user)
    {
        var role = await _userManager.GetRolesAsync(user);
        var tokenDescriptor = GetSecurityTokenDescriptor(user, role);
        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);
        var token = tokenHandler.WriteToken(securityToken);
        var refreshToken = GenerateRefreshToken(user);

        return new AuthResponse
        {
            Token = token,
            RefreshToken = refreshToken.Token,
            Expiration = DateTimeOffset.Now.AddMinutes(120)
        };
    }

    private SecurityTokenDescriptor GetSecurityTokenDescriptor(ApplicationUser user, IEnumerable<string> role)
    {
        var options = new IdentityOptions();
        var chars = /*_appSettings.Value.Secret;*/ "rJMqOvic61jeG9rwULfmMHJwZ7Kws4xeTPcqj2p1TFP42EZrUU86jq18zecn4Is";
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chars));
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                    new Claim("userID", user.Id.ToString()),
                    new Claim(options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())
            }),
            Expires = DateTime.UtcNow.AddMinutes(120),
            SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
        };
        return tokenDescriptor;
    }

    private RefreshToken GenerateRefreshToken(ApplicationUser user)
    {
        var refreshToken = new RefreshToken
        {
            User = user,
            Token = Guid.NewGuid().ToString().Replace("-", string.Empty),
            Expiration = DateTime.UtcNow.AddMinutes(150)
        };

        _context.RefreshTokens.Add(refreshToken);
        _context.SaveChanges();

        return refreshToken;
    }
}
