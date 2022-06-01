using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class MensagemPersonalizadaViewModel : ViewModel<MensagemPersonalizada>
    {
        public override int Id => IdMensagemPersonalizada;

        public int IdMensagemPersonalizada { get; set; }
        public string Codigo { get; set; }
        public string Mensagem { get; set; }
    }
}
