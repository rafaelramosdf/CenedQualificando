using System.Collections.Generic;
using System.Linq;
using CenedQualificando.CrossCutting.Dtos.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Enumerations;

namespace CenedQualificando.CrossCutting.Dtos
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
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoCadastro>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoCadastro, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoEtiqueta>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoEtiqueta, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoRelatorio>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoRelatorio, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoMensagem>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoMensagem, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoDocumento>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoDocumento, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoConfiguracoes>().Select(permissao => new PermissaoDto(TipoPermissao.PermissaoConfiguracoes, permissao)));

            return todasPermissoes;
        }
    }
}
