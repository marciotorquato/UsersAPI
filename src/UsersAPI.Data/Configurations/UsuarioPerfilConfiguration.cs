using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersApi.Domain.Entities;

namespace UsersAPI.Data.Configurations
{
    public class UsuarioPerfilConfiguration : IEntityTypeConfiguration<UsuarioPerfil>
    {
        public void Configure(EntityTypeBuilder<UsuarioPerfil> builder)
        {
            builder.ToTable("UsuarioPerfil");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("uniqueidentifier");

            builder.Property(p => p.UsuarioId).HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(p => p.NomeCompleto)
                .HasMaxLength(300)
                .HasColumnType("nvarchar(300)");

            builder.Property(p => p.DataNascimento).HasColumnType("datetimeoffset");
            builder.Property(p => p.Pais).HasMaxLength(100).HasColumnType("nvarchar(100)");
            builder.Property(p => p.AvatarUrl).HasMaxLength(1000).HasColumnType("nvarchar(1000)");

            builder.HasIndex(p => p.UsuarioId).HasDatabaseName("IX_UsuarioPerfil_UsuarioId");
        }
    }
}