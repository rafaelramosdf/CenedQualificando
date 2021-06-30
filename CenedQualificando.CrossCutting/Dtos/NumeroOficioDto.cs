using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.CrossCutting.Dtos
{
    public partial class NumeroOficioDto : Dto<NumeroOficio>
    {
        public override int Id => IdNumeroOficio;

        public int IdNumeroOficio { get; set; }
        public int Numero { get; set; }
        public int Ano { get; set; }
    }
}
