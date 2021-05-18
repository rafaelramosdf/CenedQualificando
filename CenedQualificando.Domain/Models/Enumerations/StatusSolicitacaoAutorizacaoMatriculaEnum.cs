
using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations {
    [DefaultValue(Todas)]
    public enum StatusSolicitacaoAutorizacaoMatriculaEnum
    {
        [Description("Pendente")]
        Pendente = 0,
        [Description("Autorizado")]
        Autorizado = 1, 
        [Description("Não Autorizado")]
        NaoAutorizado = 2,
        [Description("Matriculado")]
        Matriculado = 3,
        [Description("Todas")]
        Todas = 4
    }
}
