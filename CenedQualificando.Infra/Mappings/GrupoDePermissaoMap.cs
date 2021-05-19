using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class GrupoDePermissaoMap : IEntityTypeConfiguration<GrupoDePermissao>
    {
        public void Configure(EntityTypeBuilder<GrupoDePermissao> builder)
        {
            builder.HasKey(e => e.IdGrupoDePermissao)
                     .HasName("PK_Penitenciario.GrupoDePermissao");

            builder.Property(c => c.IdGrupoDePermissao)
                .HasDefaultValueSql("NEXT VALUE FOR SequencialGrupoDePermissao");

            builder.ToTable("GrupoDePermissao", "Penitenciario");
        }
    }
}
