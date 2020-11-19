//Criar em tempo de designer as tabelas no banco e suas migrações

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //var connectionString = "Server=localhost;Port=3306;Database=Course;Uid=root;Pwd=admin";
            var connectionString = "Server=#####;Database=db_Sentinella_Web;User Id=usr_sentinella;Password=#####;";
            var optionBuilder = new DbContextOptionsBuilder<MyContext>();
            //optionBuilder.UseMySql(connectionString);
            optionBuilder.UseSqlServer(connectionString);
            return new MyContext(optionBuilder.Options);
        }
    }
}
;
