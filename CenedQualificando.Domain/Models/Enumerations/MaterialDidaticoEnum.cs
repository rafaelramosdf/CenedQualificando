
using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations {
    [DefaultValue(Null)]
    public enum MaterialDidaticoEnum {
        [Description("")]
        Null = 0,
        [Description("Apostila")]
        Apostila = 1, 
        [Description("Apostila e Prova")]
        ApostilaProva = 2
    }
}
