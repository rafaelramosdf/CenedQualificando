using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Queries.Filters.Base;
using CenedQualificando.Domain.Resources;
using CenedQualificando.Web.Admin.Services.RefitApiServices.Base;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class ListPageBase<TEntity, TFilter, TViewModel, TApiService> : PageBase
        where TEntity : Entity 
        where TFilter : Filter
        where TViewModel : ViewModel<TEntity> 
        where TApiService : ICRUDService<TEntity, TFilter, TViewModel> 
    {
        [Inject] protected TApiService ApiService { get; set; }
        [Inject] protected IDialogService Dialog { get; set; }

        protected bool SomenteLeitura = true;
        protected TFilter Filtro = Activator.CreateInstance<TFilter>();
        protected TViewModel ItemSelecionado = null;
        protected HashSet<TViewModel> Selecionados = new HashSet<TViewModel>();

        protected MudTable<TViewModel> Table;
        protected DataTableModel<TViewModel> DataTable;

        protected void OnSearch(string text)
        {
            Filtro.Search = text;
            Table.ReloadServerData();
        }

        protected async Task<TableData<TViewModel>> ServerReload(TableState state)
        {
            DataTable = new DataTableModel<TViewModel>();

            DataTable.Sorting.Desc = state.SortDirection == SortDirection.Descending;
            DataTable = Ordenar(DataTable, state);

            DataTable.Pagination.Page = state.Page + 1;
            DataTable.Pagination.Limit = state.PageSize;

            DataTable = await Buscar(Filtro);

            return new TableData<TViewModel>() { TotalItems = DataTable.Pagination.Total, Items = DataTable.Data };
        }

        protected virtual DataTableModel<TViewModel> Ordenar(DataTableModel<TViewModel> dataTable, TableState state)
        {
            dataTable.Sorting.Field = state.SortLabel;
            return dataTable;
        }

        protected virtual async Task<DataTableModel<TViewModel>> Buscar(TFilter filtro)
        {
            State.Carregando = true;
            var dataTable = await ApiService.Buscar(filtro);
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
