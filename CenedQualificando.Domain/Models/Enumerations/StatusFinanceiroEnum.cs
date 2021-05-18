
using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations {
    [DefaultValue(Null)]
    public enum StatusFinanceiroEnum {
        [Description("")]
        Null = 0,
        [Description("Pendente")]
        Pendente = 1, 
        [Description("Pago")]
        Pago = 2,
        [Description("Bolsa de Estudo")]
        BolsaEstudo = 3,
        [Description("Reposição de Curso")]
        ReposicaoDeCurso = 4,
        [Description("Pagamento com Desconto")]
        PagamentoComDesconto = 5,
        [Description("Crédito Transferido")]
        CreditoTransferido = 6
    }
}
