using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Utils;
using CenedQualificando.Domain.Resources;
using CenedQualificando.Web.Admin.Services.RefitApiServices.Base;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class ListPageBase<TEntity, TDto, TApiService> : PageBase
        where TEntity : Entity 
        where TDto : Dto<TEntity> 
        where TApiService : ICRUDService<TEntity, TDto> 
    {
        [Inject] protected TApiService ApiService { get; set; }
        [Inject] protected IDialogService Dialog { get; set; }

        protected bool SomenteLeitura = true;
        protected string FiltroTexto = "";
        protected TDto ItemSelecionado = null;
        protected HashSet<TDto> Selecionados = new HashSet<TDto>();

        protected MudTable<TDto> Table;
        protected DataTableModel<TDto> DataTable;

        protected void OnSearch(string text)
        {
            FiltroTexto = text;
            Table.ReloadServerData();
        }

        protected async Task<TableData<TDto>> ServerReload(TableState state)
        {
            DataTable = new DataTableModel<TDto>();

            DataTable.Sorting.Desc = state.SortDirection == SortDirection.Descending;
            DataTable = Ordenar(DataTable, state);

            DataTable.Pagination.Page = state.Page + 1;
            DataTable.Pagination.Limit = state.PageSize;

            DataTable = await Buscar(DataTable);

            return new TableData<TDto>() { TotalItems = DataTable.Pagination.Total, Items = DataTable.Data };
        }

        protected virtual DataTableModel<TDto> Ordenar(DataTableModel<TDto> dataTable, TableState state)
        {
            dataTable.Sorting.Field = state.SortLabel;
            return dataTable;
        }

        protected virtual async Task<DataTableModel<TDto>> Buscar(DataTableModel<TDto> dataTable)
        {
            State.Carregando = true;
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await ApiService.Filtrar(dataTable);
            State.Carregando = false;
            return dataTable;
        }

        protected async Task Excluir(int id)
        {
            bool? excluir = await Dialog.ShowMessageBox("Excluir",
                GeneralMessageResource.DesejaRealmenteExcluirEsteRegistro,
                yesText: "Sim", cancelText: "Não");

            if (excluir == true)
            {
                State.Carregando = true;
                CommandResult apiResponse = await ApiService.Excluir(id);
                State.Carregando = false;

                if (apiResponse == null || apiResponse.HasError)
                {
                    Alert(Severity.Error, apiResponse.Errors.ToList());
                }
                else
                {
                    Alert(Severity.Success, GeneralMessageResource.RegistroExcluidoComSucesso);
                    await Table.ReloadServerData();
                }
            }
        }
    }
}
