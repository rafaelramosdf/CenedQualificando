using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Infra.Mappings
{
    public class TokenMap : IEntityTypeConfiguration<Token>
    {
        public void Configure(EntityTypeBuilder<Token> builder)
        {
            builder.HasKey(e => e.IdToken)
                    .HasName("PK_Penitenciario.Token");

            builder.Property(c => c.IdToken)
               .HasDefaultValueSql("NEXT VALUE FOR SequencialToken");

            builder.ToTable("Token", "Penitenciario");

            builder.Property(e => e.Cpf).IsRequired();

            builder.Property(e => e.IdCurso).IsRequired();

            builder.Property(e => e.Referencia).IsRequired();

            builder.Property(e => e.ValorTotal).HasColumnType("decimal(18, 2)");
        }
    }
}
