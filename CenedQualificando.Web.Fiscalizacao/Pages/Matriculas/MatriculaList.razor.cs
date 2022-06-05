﻿using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using CenedQualificando.Domain.Models.Base;
using System.Threading.Tasks;
using CenedQualificando.Web.Fiscalizacao.Shared.CodeBase.Pages;
using CenedQualificando.Web.Fiscalizacao.Services.ApiContracts;
using static MudBlazor.CategoryTypes;

namespace CenedQualificando.Web.Fiscalizacao.Pages.Matriculas
{
    public partial class MatriculaList : PageBase
    {
        [Inject] protected IMatriculaApiContract MatriculasApiService { get; set; }
        [Inject] protected IDialogService Dialog { get; set; }

        protected bool SomenteLeitura = true;
        protected MatriculaFilter Filtro = new MatriculaFilter();
        protected MatriculaViewModel ItemSelecionado = null;
        protected HashSet<MatriculaViewModel> Selecionados = new HashSet<MatriculaViewModel>();

        protected MudTable<MatriculaViewModel> Table;
        protected DataTableModel<MatriculaViewModel> DataTable;

        protected void OnSearch(string text)
        {
            Filtro.Search = text;
            Table.ReloadServerData();
        }

        protected async Task<TableData<MatriculaViewModel>> ServerReload(TableState state)
        {
            DataTable = new DataTableModel<MatriculaViewModel>();

            Filtro.Desc = state.SortDirection == SortDirection.Descending;
            Filtro.SortingField = state.SortLabel;

            Filtro.Page = state.Page + 1;
            Filtro.Limit = state.PageSize;

            State.Carregando = true;
            DataTable = await MatriculasApiService.Buscar(Filtro);
            State.Carregando = false;

            return new TableData<MatriculaViewModel>() { TotalItems = DataTable.Pagination.Total, Items = DataTable.Data };
        }

        private TableGroupDefinition<MatriculaViewModel> GroupDefinition = new()
        {
            GroupName = "Penitenciaria",
            Indentation = false,
            Expandable = false,
            Selector = (e) => e.IdPenitenciaria
        };
    }
}
