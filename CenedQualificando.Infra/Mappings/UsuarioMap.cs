using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.IdUsuario)
                    .HasName("PK_Penitenciario.Usuario");

            builder.Property(c => c.IdUsuario)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialUsuario");

            builder.ToTable("Usuario", "Penitenciario");

            builder.HasIndex(e => e.IdGrupoDePermissao)
                .HasDatabaseName("IX_IdGrupoDePermissao");

            builder.Property(e => e.ConfirmarSenha).IsRequired();

            builder.Property(e => e.DataExpiracaoSenha).HasColumnType("datetime");

            builder.Property(e => e.Email).IsRequired();

            builder.Property(e => e.Login).IsRequired();

            builder.Property(e => e.Nome).IsRequired();

            builder.Property(e => e.Senha).IsRequired();

            builder.HasOne(d => d.IdGrupoDePermissaoNavigation)
                .WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdGrupoDePermissao)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Penitenciario.Usuario_Penitenciario.GrupoDePermissao_IdGrupoDePermissao");
        }
    }
}
