using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class MensagemPersonalizadaDto : Dto<MensagemPersonalizada>
    {
        public override int Id => IdMensagemPersonalizada;

        public int IdMensagemPersonalizada { get; set; }
        public string Codigo { get; set; }
        public string Mensagem { get; set; }

        public override void Validate()
        {
        }
    }
}
