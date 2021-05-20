using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class NumeroCertificadoDto : Dto<NumeroCertificado>
    {
        public override int Id => IdNumeroCertificado;

        public int IdNumeroCertificado { get; set; }
        public string Prefixo { get; set; }
        public int Numero { get; set; }
        public string Criptografia { get; set; }
        public int IdMatricula { get; set; }

        public override void Validate()
        {
        }
    }
}
