using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    [DefaultValue(Null)]
    public enum CondicaoPresoEnum
    {
        [Description("")]
        Null = 0,
        [Description("Sentenciado")]
        Sentenciado,
        [Description("Aguardando Sentença")]
        AguardandoSentenca
    }
}
