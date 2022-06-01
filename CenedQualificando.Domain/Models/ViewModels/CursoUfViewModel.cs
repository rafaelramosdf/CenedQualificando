using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class CursoUfViewModel : ViewModel<CursoUf>
    {
        public override int Id => IdCursoUf;

        public int IdCursoUf { get; set; }
        public int Uf { get; set; }
    }
}
