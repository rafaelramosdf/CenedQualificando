using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class FiscalSalaMap : IEntityTypeConfiguration<FiscalSala>
    {
        public void Configure(EntityTypeBuilder<FiscalSala> builder)
        {
            builder.Property(c => c.IdFiscalSala)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialFiscalSala");

            builder.HasKey(e => e.IdFiscalSala)
                    .HasName("PK_Penitenciario.FiscalSala");

            builder.ToTable("FiscalSala", "Penitenciario");

            builder.Property(e => e.Nome).IsRequired();
        }
    }
}
