using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class CargaHorariaDiariaDto : Dto<CargaHorariaDiaria>
    {
        public override int Id => IdCargaHorariaDiaria;

        public int IdCargaHorariaDiaria { get; set; }
        public int CargaHoraria { get; set; }
        public int Uf { get; set; }

        public override void Validate()
        {
        }
    }
}
