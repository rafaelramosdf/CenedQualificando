using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class RepresentanteDto : Dto<Representante>
    {
        public override int Id => IdRepresentante;

        public int IdRepresentante { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public int Uf { get; set; }
        public int Ativo { get; set; }

        public override void Validate()
        {
        }
    }
}
