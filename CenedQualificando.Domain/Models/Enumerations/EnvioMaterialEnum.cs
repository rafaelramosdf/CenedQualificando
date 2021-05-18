using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    public enum EnvioMaterialEnum
    {
        [Description("")]
        Null = 0,
        [Description("Via e-mail, em arquivo PDF")]
        PorEmail,
        [Description("Apostila impressa para o endereço residencial")]
        ImpressoParaResidencia,
        [Description("Apostila impressa para a Penitenciária do Interno")]
        ImpressoParaPenitenciaria
    }
}