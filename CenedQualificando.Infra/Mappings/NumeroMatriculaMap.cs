using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class NumeroMatriculaMap : IEntityTypeConfiguration<NumeroMatricula>
    {
        public void Configure(EntityTypeBuilder<NumeroMatricula> builder)
        {
            builder.HasKey(e => e.IdNumeroMatricula)
                    .HasName("PK_Penitenciario.NumeroMatricula");

            builder.Property(c => c.IdNumeroMatricula)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialNumeroMatricula");

            builder.ToTable("NumeroMatricula", "Penitenciario");

            builder.Property(e => e.IdNumeroMatricula).ValueGeneratedNever();
        }
    }
}
