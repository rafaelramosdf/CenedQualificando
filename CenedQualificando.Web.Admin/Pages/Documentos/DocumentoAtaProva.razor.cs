using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class DocumentoAtaProva : PageBase
    {
        [Inject] protected IMatriculaService MatriculaService { get; set; }

        protected string FiltroTexto = "";
        protected IEnumerable<MatriculaDto> Lista = new List<MatriculaDto>();
        protected HashSet<MatriculaDto> Selecionados = new HashSet<MatriculaDto>();

        protected override void OnInit()
        {
            State.TituloPagina = "Documentos / Ata de Prova";
        }

        protected async Task<DataTableModel<MatriculaDto>> Buscar(DataTableModel<MatriculaDto> dataTable)
        {
            State.Carregando = true;
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await MatriculaService.Filtrar(dataTable);
            State.Carregando = false;
            return dataTable;
        }
    }
}
