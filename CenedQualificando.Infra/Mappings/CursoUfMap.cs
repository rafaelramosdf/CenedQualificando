using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class CursoUfMap : IEntityTypeConfiguration<CursoUf>
    {
        public void Configure(EntityTypeBuilder<CursoUf> builder)
        {
            builder.HasKey(e => e.IdCursoUf)
                    .HasName("PK_Penitenciario.CursoUf");

            builder.Property(c => c.IdCursoUf)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialCursoUf");

            builder.ToTable("CursoUf", "Penitenciario");
        }
    }
}
