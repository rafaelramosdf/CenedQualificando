using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    public enum TipoDeclaracaoEnum
    {
        [Description("Declaração cursos concluídos")]
        DeclaracaoCursosConcluidos = 1,
        [Description("Declaração curso em andamento")]
        DeclaracaoCursoEmAndamento = 2
    }
}
