using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class CursoList : ListPageBase<CursoDto>
    {
        [Inject] protected ICursoService CursoService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Cursos CENED / Lista";
        }

        protected override async Task<DataTableModel<CursoDto>> Buscar(DataTableModel<CursoDto> dataTable)
        {
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await CursoService.Filtrar(dataTable);
            return dataTable;
        }
    }
}
