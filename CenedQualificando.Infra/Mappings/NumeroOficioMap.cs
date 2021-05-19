using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class NumeroOficioMap : IEntityTypeConfiguration<NumeroOficio>
    {
        public void Configure(EntityTypeBuilder<NumeroOficio> builder)
        {
            builder.HasKey(e => e.IdNumeroOficio)
                     .HasName("PK_Penitenciario.NumeroOficio");

            builder.Property(c => c.IdNumeroOficio)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialNumeroOficio");

            builder.ToTable("NumeroOficio", "Penitenciario");

            builder.Property(e => e.IdNumeroOficio).ValueGeneratedNever();
        }
    }
}
