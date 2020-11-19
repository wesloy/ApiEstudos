using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;


//referenciando as entidade (tabelas) do sistema

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {

        //Tabelas do sistema
        public DbSet<UserEntity> Users { get; set; }

        //Construtor (metodo) do Entity FrameWork
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        //Override para auto criação do mapiamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Cada um dos comandos abaixo faz:
            //Pega a Entity do Domain, verifica como ela deve ser criada no Mapping e executa a criação

            //criacao de cada uma das tabelas relationadas acima nos DbSet
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
        }


    }
}
