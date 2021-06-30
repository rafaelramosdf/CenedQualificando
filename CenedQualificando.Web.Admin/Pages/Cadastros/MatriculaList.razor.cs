using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Utils;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class MatriculaList : ListPageBase<MatriculaDto>
    {
        [Inject] protected IMatriculaApiService MatriculaApiService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Matriculas / Lista";
            SomenteLeitura = true;
        }

        protected override async Task<DataTableModel<MatriculaDto>> Buscar(DataTableModel<MatriculaDto> dataTable)
        {
            State.Carregando = true;
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await MatriculaApiService.Filtrar(dataTable);
            State.Carregando = false;
            return dataTable;
        }
    }
}
