using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations {
    [DefaultValue(Null)]
    public enum SexoEnum {
        [Description("")]
        Null = 0,
        [Description("M")]
        M = 1, 
        [Description("F")]
        F = 2
    }
}
