using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersApi.Domain.Entities;

namespace UsersAPI.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("uniqueidentifier");

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar(200)");

            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar(200)");

            builder.HasIndex(u => u.Nome).HasDatabaseName("IX_Usuario_Nome");


            builder.Property(u => u.Ativo).HasColumnType("bit").IsRequired();
            builder.Property(u => u.DataCriacao).HasColumnType("datetimeoffset").IsRequired();
            builder.Property(u => u.DataAtualizacao).HasColumnType("datetimeoffset");


            builder.HasOne(u => u.Perfil)
                .WithOne(p => p.Usuario)
                .HasForeignKey<UsuarioPerfil>(p => p.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Contatos)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Enderecos)
                .WithOne(e => e.Usuario)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UsuarioRoles)
                .WithOne(ur => ur.Usuario)
                .HasForeignKey(ur => ur.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}