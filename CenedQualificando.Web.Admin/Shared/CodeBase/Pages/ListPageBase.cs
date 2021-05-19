using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Objects;
using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class ListPageBase<TModel> : PageBase
        where TModel : class
    {
        protected bool SomenteLeitura = false;
        protected string FiltroTexto = "";
        protected TModel ItemSelecionado = null;
        protected HashSet<TModel> Selecionados = new HashSet<TModel>();

        protected MudTable<TModel> Table;
        protected DataTableModel<TModel> DataTable;

        protected void OnSearch(string text)
        {
            FiltroTexto = text;
            Table.ReloadServerData();
        }

        protected async Task<TableData<TModel>> ServerReload(TableState state)
        {
            DataTable = new DataTableModel<TModel>();

            DataTable.Sorting.Desc = state.SortDirection == SortDirection.Descending;
            DataTable = Ordenar(DataTable, state);

            DataTable.Pagination.Page = state.Page + 1;
            DataTable.Pagination.Limit = state.PageSize;

            DataTable = await Buscar(DataTable);

            return new TableData<TModel>() { TotalItems = DataTable.Pagination.Total, Items = DataTable.Data };
        }

        protected virtual DataTableModel<TModel> Ordenar(DataTableModel<TModel> dataTable, TableState state)
        {
            dataTable.Sorting.Field = state.SortLabel;
            return dataTable;
        }

        protected virtual async Task<DataTableModel<TModel>> Buscar(DataTableModel<TModel> dataTable)
        {
            return await Task.Run(() => dataTable);
        }
    }
}
