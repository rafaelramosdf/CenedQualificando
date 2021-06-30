using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.CrossCutting.Dtos
{
    public partial class MensagemPersonalizadaDto : Dto<MensagemPersonalizada>
    {
        public override int Id => IdMensagemPersonalizada;

        public int IdMensagemPersonalizada { get; set; }
        public string Codigo { get; set; }
        public string Mensagem { get; set; }
    }
}
