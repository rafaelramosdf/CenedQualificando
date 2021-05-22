using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class UsuarioList : ListPageBase<UsuarioDto>
    {
        [Inject] protected IUsuarioService UsuarioService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Usuários do Sistema / Lista";
        }

        protected override async Task<DataTableModel<UsuarioDto>> Buscar(DataTableModel<UsuarioDto> dataTable)
        {
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await UsuarioService.Filtrar(dataTable);
            return dataTable;
        }
    }
}
