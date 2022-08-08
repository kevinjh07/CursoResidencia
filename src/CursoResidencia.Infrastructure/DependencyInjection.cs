using CursoResidencia.Domain.Interfaces.Services;
using CursoResidencia.Infrastructure.Services;

namespace CursoResidencia.Infrastructure;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHelloWorldService, HelloWorldService>();
        return services;
    }
}