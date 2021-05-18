using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class TabelaCursosAutorizadosMap : IEntityTypeConfiguration<TabelaCursosAutorizados>
    {
        public void Configure(EntityTypeBuilder<TabelaCursosAutorizados> builder)
        {
            builder.HasKey(e => e.IdTabelaCursosAutorizados)
                    .HasName("PK_Penitenciario.TabelaCursosAutorizados");

            builder.Property(c => c.IdTabelaCursosAutorizados)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialTabelaCursosAutorizados");

            builder.ToTable("TabelaCursosAutorizados", "Penitenciario");

            builder.Property(e => e.DataCadastro).HasColumnType("datetime");
        }
    }
}
