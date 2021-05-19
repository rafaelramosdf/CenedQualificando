using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class TabelaHistoricoCursoMap : IEntityTypeConfiguration<TabelaHistoricoCurso>
    {
        public void Configure(EntityTypeBuilder<TabelaHistoricoCurso> builder)
        {
            builder.HasKey(e => e.IdTabelaHistoricoCurso)
                    .HasName("PK_Penitenciario.TabelaHistoricoCurso");

            builder.Property(c => c.IdTabelaHistoricoCurso)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialTabelaHistoricoCurso");

            builder.ToTable("TabelaHistoricoCurso", "Penitenciario");
        }
    }
}
