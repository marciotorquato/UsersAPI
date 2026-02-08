using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersApi.Domain.Entities;

namespace UsersAPI.Data.Configurations
{
    public class ContatoConfiguration : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.ToTable("Contato");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnType("uniqueidentifier");

            builder.Property(c => c.UsuarioId).HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(c => c.Celular).HasMaxLength(50).HasColumnType("nvarchar(50)");
            builder.Property(c => c.Email).HasMaxLength(320).HasColumnType("nvarchar(320)");

            builder.HasIndex(c => c.UsuarioId).HasDatabaseName("IX_Contato_UsuarioId");
        }
    }
}