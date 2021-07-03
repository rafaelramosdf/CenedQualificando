using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class UsuarioList : ListPageBase<UsuarioDto>
    {
        [Inject] protected IUsuarioApiService UsuarioApiService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Usuários do Sistema / Lista";
        }

        protected override async Task<DataTableModel<UsuarioDto>> Buscar(DataTableModel<UsuarioDto> dataTable)
        {
            State.Carregando = true;
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await UsuarioApiService.Filtrar(dataTable);
            State.Carregando = false;
            return dataTable;
        }
    }
}
