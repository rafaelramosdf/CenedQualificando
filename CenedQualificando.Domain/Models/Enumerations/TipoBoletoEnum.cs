using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CenedQualificando.Domain.Models.Enumerations
{
    [DefaultValue(BoletoMatricula)]
    public enum TipoBoletoEnum
    {
        [Description("Boleto de Matrícula")]
        BoletoMatricula = 0,
        [Description("Boleto de Re-Prova")]
        BoletoReprova = 1,
        [Description("Boleto de Solicitação de Certificado")]
        BoletoSolicitacaoCertificado = 2,
        [Description("Boleto de Teste")]
        BoletoTeste = 3
    }
}
