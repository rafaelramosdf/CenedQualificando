using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class AlunoList : ListPageBase<AlunoDto>
    {
        [Inject] protected IAlunoService AlunoService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Alunos / Lista";
            SomenteLeitura = true;
        }
        
        protected override async Task<DataTableModel<AlunoDto>> Buscar(DataTableModel<AlunoDto> dataTable)
        {
            State.Carregando = true;
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await AlunoService.Filtrar(dataTable);
            State.Carregando = false;
            return dataTable;
        }
    }
}
