
using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations.Filters 
{
    [DefaultValue(Null)]
    public enum MatriculaFilterEnum
    {
        Null = 0,
        SomenteMatriculaSemDataInicio = 1,
        SomenteMatriculaSemDataCertificadoExpedido = 2,
        SomenteMatriculaComProvaAutorizada = 3
    }
}
