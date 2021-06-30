using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.CrossCutting.Dtos
{
    public partial class GruposProvaUfDto : Dto<GruposProvaUf>
    {
        public override int Id => IdGruposProvaUf;

        public int IdGruposProvaUf { get; set; }
        public int IdGrupoProva { get; set; }
        public int Uf { get; set; }
    }
}
