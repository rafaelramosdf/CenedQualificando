using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class RepresentanteMap : IEntityTypeConfiguration<Representante>
    {
        public void Configure(EntityTypeBuilder<Representante> builder)
        {
            builder.HasKey(e => e.IdRepresentante)
                    .HasName("PK_Penitenciario.Representante");

            builder.Property(c => c.IdRepresentante)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialRepresentante");

            builder.ToTable("Representante", "Penitenciario");

            builder.Property(e => e.Nome).IsRequired();
        }
    }
}
