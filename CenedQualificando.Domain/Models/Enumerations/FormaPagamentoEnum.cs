
using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations {
    [DefaultValue(Null)]
    public enum FormaPagamentoEnum {
        [Description("")]
        Null = 0,
        [Description("Boleto CEF")]
        BoletoCef = 1,
        [Description("Boleto BB")]
        BoletoBb = 2,
        [Description("Boleto BRB")]
        BoletoBrb = 3,
        [Description("Cheque")]
        Cheque = 4,
        [Description("Espécie")]
        Especie = 5,
        [Description("Depósito")]
        Deposito = 6,
        [Description("Cartão")]
        Cartao = 7,
        [Description("Cielo")]
        Cielo = 8
    }
}
