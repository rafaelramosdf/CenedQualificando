using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    public enum PeriodoDiasEnum
    {
        [Description("Indefinido")]
        Indefinido = 0,

        [Description("Hoje")]
        Hoje = 1,

        [Description("Ontem")]
        Ontem = 2,

        [Description("Últimos 3 dias")]
        Ultimos3Dias = 3,

        [Description("Últimos 7 dias")]
        Ultimos7Dias = 7,

        [Description("Últimos 14 dias")]
        Ultimos14Dias = 14,

        [Description("Últimos 30 dias")]
        Ultimos30Dias = 30,

        [Description("Últimos 90 dias")]
        Ultimos90Dias = 90
    }

    public enum PeriodoDiasDataReferenciaEnum
    {
        DataMatricula,
        DataPagamento
    }
}
