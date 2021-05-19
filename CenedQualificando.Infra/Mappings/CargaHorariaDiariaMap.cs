using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class CargaHorariaDiariaMap : IEntityTypeConfiguration<CargaHorariaDiaria>
    {
        public void Configure(EntityTypeBuilder<CargaHorariaDiaria> builder)
        {
            builder.HasKey(e => e.IdCargaHorariaDiaria)
                   .HasName("PK_Penitenciario.CargaHorariaDiaria");

            builder.Property(c => c.IdCargaHorariaDiaria)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialCargaHorariaDiaria");

            builder.ToTable("CargaHorariaDiaria", "Penitenciario");
        }
    }
}
