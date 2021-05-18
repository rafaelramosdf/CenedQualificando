
using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations {
    [DefaultValue(Null)]
    public enum MatriculaCustomFilterEnum
    {
        Null = 0,
        SomenteMatriculaSemDataInicio = 1,
        SomenteMatriculaSemDataCertificadoExpedido = 2,
    }
}
