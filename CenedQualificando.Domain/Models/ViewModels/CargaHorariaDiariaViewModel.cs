using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class CargaHorariaDiariaViewModel : ViewModel<CargaHorariaDiaria>
    {
        public override int Id => IdCargaHorariaDiaria;

        public int IdCargaHorariaDiaria { get; set; }
        public int CargaHoraria { get; set; }
        public int Uf { get; set; }
    }
}
