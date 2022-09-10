using CursoResidencia.Domain.Interfaces.Services;

namespace CursoResidencia.Infrastructure.Services
{
    public class HelloWorldService : IHelloWorldService
    {
        public async Task<HelloWorldResponse> Create(string userName, int userLevel)
        {
            await Task.Delay(2000);
            return new HelloWorldResponse
            {
                UserId = Guid.NewGuid(),
                Level = userLevel,
                UserName = userName
            };
        }
    }
}