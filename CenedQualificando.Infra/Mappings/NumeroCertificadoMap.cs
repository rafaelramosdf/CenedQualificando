using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class NumeroCertificadoMap : IEntityTypeConfiguration<NumeroCertificado>
    {
        public void Configure(EntityTypeBuilder<NumeroCertificado> builder)
        {
            builder.HasKey(e => e.IdNumeroCertificado)
                    .HasName("PK_Penitenciario.NumeroCertificado");

            builder.Property(c => c.IdNumeroCertificado)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialNumeroCertificado");

            builder.ToTable("NumeroCertificado", "Penitenciario");
        }
    }
}
