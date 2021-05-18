using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    public enum StatusCursoEnum
    {
        [Description("")]
        Null = 0,

        [Description("Aguardando Pagamento")]
        AguardandoPagamento = 1,

        [Description("Em Andamento")]
        EmAndamento = 2,

        [Description("Aprovado")]
        Aprovado = 3,

        [Description("Não Aprovado")]
        NaoAprovado = 4,

        [Description("Cancelado")]
        Cancelado = 5,

        [Description("Agendado")]
        Agendado = 6,

        [Description("Re-Prova")]
        ReProva = 7
    }
}
