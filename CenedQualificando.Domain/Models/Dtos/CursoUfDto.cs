using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class CursoUfDto : Dto<CursoUf>
    {
        public override int Id => IdCursoUf;

        public int IdCursoUf { get; set; }
        public int Uf { get; set; }
    }
}
