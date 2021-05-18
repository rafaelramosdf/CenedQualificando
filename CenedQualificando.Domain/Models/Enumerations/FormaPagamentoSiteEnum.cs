
using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations {
    [DefaultValue(Null)]
    public enum FormaPagamentoSiteEnum {

        [Description("")]
        Null = 0,

        [Description("Boleto Bancário")]
        Boleto = 1,

        [Description("Cartão de Crédito / Débito")]
        Cielo = 2,
    }
}
