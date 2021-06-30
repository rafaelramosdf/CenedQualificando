using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.CrossCutting.Dtos
{
    public partial class CargaHorariaDiariaDto : Dto<CargaHorariaDiaria>
    {
        public override int Id => IdCargaHorariaDiaria;

        public int IdCargaHorariaDiaria { get; set; }
        public int CargaHoraria { get; set; }
        public int Uf { get; set; }
    }
}
