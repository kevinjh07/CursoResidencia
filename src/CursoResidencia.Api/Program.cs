using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using StackSpot.ErrorHandler;
using CursoResidencia.Application.Common.StackSpot;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CursoResidencia.Domain.Models;
using CursoResidencia.Infrastructure.Services;
using CursoResidencia.Domain.Interfaces.Services;
using CursoResidencia.Domain.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using CursoResidencia.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddStackSpot(builder.Configuration, builder.Environment);

builder.Services.AddHttpContextAccessor();

builder.Services.AddHealthChecks();
builder.Services.AddControllers()
       .AddFluentValidation(x => x.AutomaticValidationEnabled = false)
       .AddJsonOptions(x =>
       {
           x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
           x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
       });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CursoResidencia.Api", Version = "v1" });
});

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CursoResidenciaContext")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromHours(3);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    var secret = "rJMqOvic61jeG9rwULfmMHJwZ7Kws4xeTPcqj2p1TFP42EZrUU86jq18zecn4Is";
    var key = Encoding.ASCII.GetBytes(secret);
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;

    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = null;

    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
});

builder.Services.AddScoped<RoleManager<IdentityRole<int>>>();
builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IModuloRepository, ModuloRepository>();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CursoResidencia.Api v1"));

app.UseHealthChecks("/health");
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseErrorHandler();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.UseStackSpot(builder.Configuration, builder.Environment);

await SeedDatabase(app);

app.Run();

static async Task SeedDatabase(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    await CreateRolesAsync(roleManager);
    await CreateDefaultAdminAsync(userManager);
}

static async Task CreateRolesAsync(RoleManager<IdentityRole<int>> roleManager)
{
    string[] roleNames =
    {
        "Administrador", "Aluno"
    };
    foreach (var role in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(role);
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole<int>(role));
        }
    }
}

static async Task CreateDefaultAdminAsync(UserManager<ApplicationUser> userManager)
{
    var user = await userManager.FindByEmailAsync("admin@outlook.com");
    if (user == null)
    {
        user = new ApplicationUser
        {
            Nome = "Admin User",
            UserName = "admin@outlook.com",
            Email = "admin@outlook.com",
            EmailConfirmed = true,
            Situacao = Situacao.Ativo
        };

        var result = await userManager.CreateAsync(user, "cursoresidencia");

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Administrador");
        }
    }
}
