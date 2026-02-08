using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UsersApi.Domain.Entities;

namespace UsersAPI.Data.Configurations
{
    public class UsuarioRoleConfiguration : IEntityTypeConfiguration<UsuarioRole>
    {
        public void Configure(EntityTypeBuilder<UsuarioRole> builder)
        {
            builder.ToTable("UsuarioRole");

            builder.HasKey(ur => ur.Id);
            builder.Property(ur => ur.Id).HasColumnType("uniqueidentifier");

            builder.Property(ur => ur.UsuarioId).HasColumnType("uniqueidentifier").IsRequired();
            builder.Property(ur => ur.RoleId).IsRequired();

            builder.HasIndex(ur => ur.UsuarioId).HasDatabaseName("IX_UsuarioRole_UsuarioId");
            builder.HasIndex(ur => ur.RoleId).HasDatabaseName("IX_UsuarioRole_RoleId");

            builder.HasOne(ur => ur.Role)
                .WithMany(r => r.UsuarioRoles)
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}