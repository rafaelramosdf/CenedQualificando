using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class GruposProvaUfMap : IEntityTypeConfiguration<GruposProvaUf>
    {
        public void Configure(EntityTypeBuilder<GruposProvaUf> builder)
        {
            builder.HasKey(e => e.IdGruposProvaUf)
                    .HasName("PK_Penitenciario.GruposProvaUf");

            builder.Property(c => c.IdGruposProvaUf)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialGruposProvaUf");

            builder.ToTable("GruposProvaUf", "Penitenciario");

            builder.HasIndex(e => e.IdGrupoProva)
                .HasDatabaseName("IX_IdGrupoProva");
            
            builder.HasOne(d => d.IdGrupoProvaNavigation)
                .WithMany(p => p.GruposProvaUf)
                .HasForeignKey(d => d.IdGrupoProva)
                .HasConstraintName("FK_Penitenciario.GruposProvaUf_Penitenciario.GrupoProva_IdGrupoProva");
        }
    }
}
