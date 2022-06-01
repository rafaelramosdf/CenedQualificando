using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class NumeroMatriculaViewModel : ViewModel<NumeroMatricula>
    {
        public override int Id => IdNumeroMatricula;

        public int IdNumeroMatricula { get; set; }
        public string Prefixo { get; set; }
        public int Numero { get; set; }
    }
}
