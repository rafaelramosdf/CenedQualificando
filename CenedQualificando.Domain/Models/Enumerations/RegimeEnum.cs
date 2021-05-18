using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    [DefaultValue(Null)]
    public enum RegimeEnum
    {
        [Description("")]
        Null = 0,
        [Description("Fechado")]
        Fechado = 1,
        [Description("Semiaberto")]
        Semiaberto = 2, 
        [Description("Aberto")]
        Aberto = 3
    }
}
