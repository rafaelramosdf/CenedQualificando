using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class PenitenciariaMap : IEntityTypeConfiguration<Penitenciaria>
    {
        public void Configure(EntityTypeBuilder<Penitenciaria> builder)
        {
            builder.HasKey(e => e.IdPenitenciaria)
                    .HasName("PK_Penitenciario.Penitenciaria");

            builder.Property(c => c.IdPenitenciaria)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialPenitenciaria");

            builder.ToTable("Penitenciaria", "Penitenciario");

            builder.Property(e => e.Cep).IsRequired();

            builder.Property(e => e.Cidade).IsRequired();

            builder.Property(e => e.DataInicioBolsaParceria).HasColumnType("datetime");

            builder.Property(e => e.Endereco).IsRequired();

            builder.Property(e => e.Nome).IsRequired();
        }
    }
}
