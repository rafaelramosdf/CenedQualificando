using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models;

namespace CenedQualificando.Infra.Mappings
{
    public class GrupoProvaMap : IEntityTypeConfiguration<GrupoProva>
    {
        public void Configure(EntityTypeBuilder<GrupoProva> builder)
        {
            builder.HasKey(e => e.IdGrupoProva)
                    .HasName("PK_Penitenciario.GrupoProva");

            builder.Property(c => c.IdGrupoProva)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialGrupoProva");

            builder.ToTable("GrupoProva", "Penitenciario");
        }
    }
}
