using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    public enum TipoOficioEnum
    {
        [Description("Ofício Estados (UFs)")]
        OficioUfs = 1,
        [Description("Ofício Distrito Federal")]
        OficioDf = 2
    }
}
