using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class UfEntregaMap : IEntityTypeConfiguration<UfEntrega>
    {
        public void Configure(EntityTypeBuilder<UfEntrega> builder)
        {
            builder.HasKey(e => e.IdUf)
                    .HasName("PK_Penitenciario.UfEntrega");

            builder.Property(c => c.IdUf)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialUfEntrega");

            builder.ToTable("UfEntrega", "Penitenciario");

            builder.Property(e => e.Taxa).HasColumnType("decimal(18, 2)");
        }
    }
}
