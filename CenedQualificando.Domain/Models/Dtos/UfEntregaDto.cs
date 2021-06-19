using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class UfEntregaDto : Dto<UfEntrega>
    {
        public override int Id => IdUf;

        public int IdUf { get; set; }
        public int Uf { get; set; }
        public decimal Taxa { get; set; }
    }
}
