using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class NumeroOficioDto : Dto<NumeroOficio>
    {
        public override int Id => IdNumeroOficio;

        public int IdNumeroOficio { get; set; }
        public int Numero { get; set; }
        public int Ano { get; set; }

        public override void Validate()
        {
        }
    }
}
