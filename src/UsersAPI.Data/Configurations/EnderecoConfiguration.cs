using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersApi.Domain.Entities;

namespace UsersAPI.Data.Configurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnType("uniqueidentifier");

            builder.Property(e => e.UsuarioId).HasColumnType("uniqueidentifier").IsRequired();

            builder.Property(e => e.Rua).HasMaxLength(300).HasColumnType("nvarchar(300)");
            builder.Property(e => e.Numero).HasMaxLength(50).HasColumnType("nvarchar(50)");
            builder.Property(e => e.Complemento).HasMaxLength(200).HasColumnType("nvarchar(200)");
            builder.Property(e => e.Bairro).HasMaxLength(150).HasColumnType("nvarchar(150)");
            builder.Property(e => e.Cidade).HasMaxLength(150).HasColumnType("nvarchar(150)");
            builder.Property(e => e.Estado).HasMaxLength(100).HasColumnType("nvarchar(100)");
            builder.Property(e => e.Cep).HasMaxLength(20).HasColumnType("nvarchar(20)");

            builder.HasIndex(e => e.UsuarioId).HasDatabaseName("IX_Endereco_UsuarioId");
        }
    }
}