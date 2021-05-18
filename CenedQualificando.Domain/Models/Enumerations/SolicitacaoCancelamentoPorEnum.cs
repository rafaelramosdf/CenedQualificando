using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    [DefaultValue(Familiar)]
    public enum SolicitacaoCancelamentoPorEnum
    {
        [Description("")]
        Null = 0,
        [Description("Familiar")]
        Familiar = 1, 
        [Description("Advogado")]
        Advogado = 2,
        [Description("Visitante")]
        Visitante = 3,
        [Description("Operadora CC")]
        OperadoraCc = 4,
        [Description("Escola CENED")]
        EscolaCened = 5,
    }
}
