using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    public enum StatusRotinaEnum
    {
        [Description("")]
        Null = 0,

        [Description("Aguardando Ativação")]
        AguardandoAtivacao = 1,

        [Description("Aguardando Autorização")]
        AguardandoAutorizacao = 2,

        [Description("Aguardando Etiqueta de Apostila")]
        AguardandoEtiquetaApostila = 3,

        [Description("Aguardando Emissão da GRE de Apostila")]
        AguardandoEmissaoGreApostila = 4,

        [Description("Aguardando Finalização da GRE de Apostila")]
        AguardandoFinalizacaoGreApostila = 5,

        [Description("Material Enviado")]
        MaterialEnviado = 6,

        [Description("Aguardando Emissão de Certificado")]
        AguardandoEmissaoCertificado = 7,

        [Description("Aguardando Etiqueta de Certificado")]
        AguardandoEtiquetaCertificado = 8,

        [Description("Aguardando Emissão da GRE de Certificado")]
        AguardandoEmissaoGreCertificado = 9,

        [Description("Aguardando Finalização da GRE de Certificado")]
        AguardandoFinalizacaoGreCertificado = 10,

        [Description("Certificado Enviado")]
        CertificadoEnviado = 11,

        [Description("Aguardando Emissão de Prova de Recuperação")]
        AguardandoEmissaoProvaRecuperacao = 12,

        [Description("Aguardando Emissão do Comunicado de Recuperação")]
        AguardandoEmissaoComunicadoRecuperacao = 13,

        [Description("Aguardando Etiqueta de Prova")]
        AguardandoEtiquetaProva = 14,

        [Description("Aguardando Emissão da GRE de Prova")]
        AguardandoEmissaoGreProva = 15,

        [Description("Aguardando Finalização da GRE de Prova")]
        AguardandoFinalizacaoGreProva = 16,

        [Description("Prova Enviada")]
        ProvaEnviada = 17,
    }
}
