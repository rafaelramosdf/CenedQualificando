using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class GruposProvaUfDto : Dto<GruposProvaUf>
    {
        public override int Id => IdGruposProvaUf;

        public int IdGruposProvaUf { get; set; }
        public int IdGrupoProva { get; set; }
        public int Uf { get; set; }

        public override void Validate()
        {
        }
    }
}
