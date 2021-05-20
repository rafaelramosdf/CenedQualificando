using System.Collections.Generic;
using System.Linq;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Enumerations;

namespace CenedQualificando.Domain.Models.Dtos
{
    public class GrupoDePermissaoDto : Dto<GrupoDePermissao>
    {

        public override int Id => IdGrupoDePermissao;

        public int IdGrupoDePermissao { get; set; }
        public string Descricao { get; set; }
        public bool Oculto { get; set; }
        public IEnumerable<PermissaoDto> Permissoes { get; set; }

        public void ConfigurarPermissoes(IEnumerable<string> permissoes)
        {
            var todasPermissoes = ListarPermissoes();

            todasPermissoes.ForEach(x =>
            {
                if (permissoes.Any(p => p == x.Nome))
                    x.Selecionado = true;
            });

            Permissoes = todasPermissoes;
        }

        public List<PermissaoDto> ListarPermissoes()
        {
            var todasPermissoes = new List<PermissaoDto>();
            todasPermissoes.AddRange(EnumerationExtension.GetNames<PermissaoCadastro>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoCadastro, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.GetNames<PermissaoEtiqueta>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoEtiqueta, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.GetNames<PermissaoRelatorio>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoRelatorio, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.GetNames<PermissaoMensagem>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoMensagem, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.GetNames<PermissaoDocumento>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoDocumento, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.GetNames<PermissaoConfiguracoes>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoConfiguracoes, permissao)));

            return todasPermissoes;
        }

        public override void Validate()
        {
        }
    }
}
