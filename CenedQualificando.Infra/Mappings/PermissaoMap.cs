using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class PermissaoMap : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.HasKey(e => e.IdPermissao)
                    .HasName("PK_Penitenciario.Permissao");

            builder.Property(c => c.IdPermissao)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialPermissao");

            builder.ToTable("Permissao", "Penitenciario");

            builder.HasOne(d => d.IdGrupoDePermissaoNavigation)
                .WithMany(p => p.Permissao)
                .HasForeignKey(d => d.IdGrupoDePermissao)
                .HasConstraintName("FK_Penitenciario.Permissao_Penitenciario.GrupoDePermissao_IdGrupoDePermissao");
        }
    }
}
