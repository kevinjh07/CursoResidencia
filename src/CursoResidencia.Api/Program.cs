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
       });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CursoResidencia.Api", Version = "v1" });
});

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CursoResidenciaContext")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

builder.Services.AddScoped<RoleManager<IdentityRole<int>>>();
builder.Services.AddScoped<UserManager<ApplicationUser>>();
builder.Services.AddScoped<IHelloWorldService, HelloWorldService>();
builder.Services.AddMvc();

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CursoResidencia.Api v1"));

app.UseHealthChecks("/health");
app.UseHttpsRedirection();

app.UseErrorHandler();
app.UseRouting();

app.MapControllers();

app.UseStackSpot(builder.Configuration, builder.Environment);

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
    await CreateRolesAsync(roleManager);
    await CreateDefaultAdminAsync(userManager);
}

app.Run();

static async Task CreateRolesAsync(RoleManager<IdentityRole<int>> roleManager)
{
    string[] roleNames =
    {
        "Administrador", "Aluno", "Professor"
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
