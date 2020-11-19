using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependencieService(IServiceCollection serviceCollection)
        {
            //criado método estático para não ser necessário criar um obj para acessar o método
            //IServiceCollection >>> vem do Startup.cs (Api.Application) responsável para iniciar a aplicação

            //Após criado esse método deve ser "aplicado" na Api.Applicantion/Startup.cs
            //no método que tem a mesma assinatura
            // ConfigureService.ConfigureDependencieService(services);


            serviceCollection.AddTransient<IUserService, UserService>();
            //Está vinculaando no serviço a Interface com a classe que dá origem a Interface
            //Informações sobre tipos de manipulação dos dados:
            //Transient - Para cada operação ele vai criar uma estância nova.
            //Scoped - Para cada ciclo de "vida" ele estância uma.
            //Singleton - Uma vez iniciado no servidor NUNCA muda.

        }
    }
}
