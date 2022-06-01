using System.Collections.Generic;
using System.Linq;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Enumerations;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public class GrupoDePermissaoViewModel : ViewModel<GrupoDePermissao>
    {

        public override int Id => IdGrupoDePermissao;

        public int IdGrupoDePermissao { get; set; }
        public string Descricao { get; set; }
        public bool Oculto { get; set; }
        public IEnumerable<PermissaoViewModel> Permissoes { get; set; }

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

        public List<PermissaoViewModel> ListarPermissoes()
        {
            var todasPermissoes = new List<PermissaoViewModel>();
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoCadastro>().Select(permissao => new PermissaoViewModel(TipoPermissao.PermissaoCadastro, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoEtiqueta>().Select(permissao => new PermissaoViewModel(TipoPermissao.PermissaoEtiqueta, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoRelatorio>().Select(permissao => new PermissaoViewModel(TipoPermissao.PermissaoRelatorio, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoMensagem>().Select(permissao => new PermissaoViewModel(TipoPermissao.PermissaoMensagem, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoDocumento>().Select(permissao => new PermissaoViewModel(TipoPermissao.PermissaoDocumento, permissao)));
            todasPermissoes.AddRange(EnumerationExtension.EnumNames<PermissaoConfiguracoes>().Select(permissao => new PermissaoViewModel(TipoPermissao.PermissaoConfiguracoes, permissao)));

            return todasPermissoes;
        }
    }
}
