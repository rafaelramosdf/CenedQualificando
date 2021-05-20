using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class EstoqueMaterialDto : Dto<EstoqueMaterial>
    {
        public override int Id => IdEstoqueMaterial;

        public int IdEstoqueMaterial { get; set; }
        public int UfEstoque { get; set; }
        public int QuantidadeApostila { get; set; }
        public int QuantidadeProva { get; set; }
        public int EstoqueMinimo { get; set; }
        public int IdCurso { get; set; }

        public override void Validate()
        {
        }
    }
}
