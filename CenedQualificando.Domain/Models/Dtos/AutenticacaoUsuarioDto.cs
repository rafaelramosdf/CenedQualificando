using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Models.Dtos
{
    public class AutenticacaoUsuarioDto : IDto
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
    }
}
