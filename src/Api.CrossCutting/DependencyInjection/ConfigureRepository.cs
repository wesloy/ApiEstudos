using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            //criado método estático para não ser necessário criar um obj para acessar o método
            //IServiceCollection >>> vem do Startup.cs (Api.Application) responsável para iniciar a aplicação

            //Após criado esse método deve ser "aplicado" na Api.Applicantion/Startup.cs
            //no método que tem a mesma assinatura
            // ConfigureRepository.ConfigureDependenciesRepository(services);

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            //Está vinculaando no serviço a Interface com a classe que dá origem a Interface
            //Informações sobre tipos de manipulação dos dados:
            //Transient - Para cada operação ele vai criar uma estância nova.
            //Scoped - Para cada ciclo de "vida" ele estância uma.
            //Singleton - Uma vez iniciado no servidor NUNCA muda.

            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer("Server=#####;Database=db_Sentinella_Web;User Id=usr_sentinella;Password=#####;")
               );

        }
    }
}
