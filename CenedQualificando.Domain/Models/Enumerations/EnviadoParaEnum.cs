
using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations {
    [DefaultValue(Null)]
    public enum EnviadoParaEnum {
        [Description("")]
        Null = 0,
        [Description("Penitenciária")]
        Penitenciaria = 1, 
        [Description("Residência")]
        Residencia = 2
    }
}
