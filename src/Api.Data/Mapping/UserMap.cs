using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    //Cada método leva o nome da tabela mais o sufixo Map
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasIndex(u => u.Email)
                    .IsUnique();

            builder.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(u => u.Email)
                    .HasMaxLength(100);

        }
    }
}
