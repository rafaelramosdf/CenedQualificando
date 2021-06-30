using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.CrossCutting.Dtos
{
    public partial class CursoUfDto : Dto<CursoUf>
    {
        public override int Id => IdCursoUf;

        public int IdCursoUf { get; set; }
        public int Uf { get; set; }
    }
}
