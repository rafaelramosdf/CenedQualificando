using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class TokenDto : Dto<Token>
    {
        public override int Id => IdToken;

        public int IdToken { get; set; }
        public string Cpf { get; set; }
        public string IdCurso { get; set; }
        public string NomeCurso { get; set; }
        public decimal ValorTotal { get; set; }
        public string Referencia { get; set; }

        public override void Validate()
        {
        }
    }
}
