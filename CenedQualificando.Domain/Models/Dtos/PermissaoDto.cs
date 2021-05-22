using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class PermissaoDto : Dto<Permissao>
    {
        public PermissaoDto()
        {
        }

        public PermissaoDto(TipoPermissao tipoPermissao, string nome)
        {
            TipoPermissao = tipoPermissao;
            Nome = nome;
        }

        public override int Id => IdPermissao;

        public int IdPermissao { get; set; }
        public TipoPermissao TipoPermissao { get; set; }
        public string TipoPermissaoDescription => TipoPermissao.EnumDescription();
        public string Nome { get; set; }
        public bool Selecionado { get; set; }
        public int IdGrupoDePermissao { get; set; }

        public override void Validate()
        {
        }
    }
}
