using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class NumeroOficioViewModel : ViewModel<NumeroOficio>
    {
        public override int Id => IdNumeroOficio;

        public int IdNumeroOficio { get; set; }
        public int Numero { get; set; }
        public int Ano { get; set; }
    }
}
