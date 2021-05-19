using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class MensagemPersonalizadaMap : IEntityTypeConfiguration<MensagemPersonalizada>
    {
        public void Configure(EntityTypeBuilder<MensagemPersonalizada> builder)
        {
            builder.HasKey(e => e.IdMensagemPersonalizada)
                    .HasName("PK_Penitenciario.MensagemPersonalizada");

            builder.Property(c => c.IdMensagemPersonalizada)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialMensagemPersonalizada");

            builder.ToTable("MensagemPersonalizada", "Penitenciario");

            builder.Property(e => e.Codigo).IsRequired();

            builder.Property(e => e.Mensagem).IsRequired();
        }
    }
}
