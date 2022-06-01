using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class NumeroCertificadoViewModel : ViewModel<NumeroCertificado>
    {
        public override int Id => IdNumeroCertificado;

        public int IdNumeroCertificado { get; set; }
        public string Prefixo { get; set; }
        public int Numero { get; set; }
        public string Criptografia { get; set; }
        public int IdMatricula { get; set; }
    }
}
