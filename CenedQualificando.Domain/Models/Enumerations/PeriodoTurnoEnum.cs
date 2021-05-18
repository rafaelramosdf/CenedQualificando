using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    public enum PeriodoTurnoEnum {
        [Description("")]
        Null = 0,

        [Description("Manhã")]
        Manha = 1,

        [Description("Tarde")]
        Tarde = 2,

        [Description("Manhã e Tarde")]
        ManhaTarde = 3
    }
}
