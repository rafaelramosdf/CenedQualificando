using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class GruposProvaUfViewModel : ViewModel<GruposProvaUf>
    {
        public override int Id => IdGruposProvaUf;

        public int IdGruposProvaUf { get; set; }
        public int IdGrupoProva { get; set; }
        public int Uf { get; set; }
    }
}
