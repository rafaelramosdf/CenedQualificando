using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class NumeroMatriculaDto : Dto<NumeroMatricula>
    {
        public override int Id => IdNumeroMatricula;

        public int IdNumeroMatricula { get; set; }
        public string Prefixo { get; set; }
        public int Numero { get; set; }
    }
}
