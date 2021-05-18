using System.ComponentModel;

namespace CenedQualificando.Domain.Models.Enumerations
{
    [DefaultValue(Familiar)]
    public enum VinculoEnum
    {
        [Description("")]
        Null = 0,
        [Description("Familiar")]
        Familiar = 1, 
        [Description("Advogado")]
        Advogado = 2,
        [Description("Visitante")]
        Visitante = 3,
        [Description("Núcleo de Ensino Penitenciário")]
        NucleoEnsinoPenitenciario = 4,
        [Description("Agente Penitenciário")]
        AgentePenitenciario = 5,
        [Description("Pedagogo Penitenciário")]
        Pedagogo = 6
    }
}
