using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    public enum GrauEscolaridadeEnum
    {
        [Description("Não possui")]
        NaoPossui,

        [Description("Fundamental - Incompleto")]
        EnsinoFundamentalIncompleto,

        [Description("Fundamental - Completo")]
        EnsinoFundamentalCompleto,

        [Description("Médio - Incompleto")]
        EnsinoMedioIncompleto,

        [Description("Médio - Completo")]
        EnsinoMedioCompleto,

        [Description("Superior - Incompleto")]
        EnsinoSuperiorIncompleto,

        [Description("Superior - Completo")]
        EnsinoSuperiorCompleto,

        [Description("Pós-graduação - Incompleto")]
        PosGraduacaoIncompleto,

        [Description("Pós-graduação - Completo")]
        PosGraduacaoCompleto,

        [Description("Mestrado - Incompleto")]
        MestradoIncompleto,

        [Description("Mestrado - Completo")]
        MestradoCompleto,

        [Description("Doutorado - Incompleto")]
        DoutoradoIncompleto,

        [Description("Doutorado - Completo")]
        DoutoradoCompleto

    }
}