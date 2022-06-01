using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class ImpressaoCertificadoViewModel : ViewModel<ImpressaoCertificado>
    {
        public override int Id => IdImpressaoCertificado;

        public int IdImpressaoCertificado { get; set; }
        public int IdCurso { get; set; }
        public string Frente { get; set; }
        public string ConteudoCurso { get; set; }
    }
}
