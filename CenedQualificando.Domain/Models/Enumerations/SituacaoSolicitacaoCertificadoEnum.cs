
using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations {

    [DefaultValue(AguardandoPagamento)]
    public enum SituacaoSolicitacaoCertificadoEnum
    {
        [Description("")]
        Null = 0,

        [Description("Aguardando Pagamento")]
        AguardandoPagamento = 1, 

        [Description("Aguardando Impressão")]
        AguardandoImpressao = 2,

        [Description("Aguardando Etiqueta")]
        AguardandoEtiqueta = 3,

        [Description("Enviado")]
        Enviado = 4
    }
}
