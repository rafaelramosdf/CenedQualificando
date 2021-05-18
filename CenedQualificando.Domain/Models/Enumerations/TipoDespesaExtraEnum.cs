using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    public enum TipoDespesaExtraEnum
    {
        [Description("Despesa de Re-Prova")]
        DespesaReprova = 0,
        [Description("Despesa de Material")]
        DespesaMaterial = 1,
        [Description("Outras Despesas")]
        DespesaOutras = 2
    }
}
