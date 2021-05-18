using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CenedQualificando.Domain.Models.Enumerations
{
    [DefaultValue(SmsAutomatico)]
    public enum TipoEnvioSMSEnum
    {
        [Description("Envio Manual")]
        SmsManual = 0,
        [Description("Envio Automático")]
        SmsAutomatico = 1
    }
}
