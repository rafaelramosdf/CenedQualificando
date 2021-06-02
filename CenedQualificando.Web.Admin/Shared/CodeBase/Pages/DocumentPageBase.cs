using Blazored.LocalStorage;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Web.Admin.Shared.CodeBase.Constants;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class DocumentPageBase : ComponentBase, IDisposable
    {
        [Inject] protected StateContainer State { get; set; }
        [Inject] ISyncLocalStorageService LocalStorage { get; set; }

        protected virtual void OnInit() { }

        protected override void OnInitialized()
        {
            State.OnChange += StateHasChanged;
            OnInit();

            LocalStorage.RemoveItem(LocalStorageConstant.PENITENCIARIA_SELECIONADA_KEY);
            LocalStorage.RemoveItem(LocalStorageConstant.MATRICULA_SELECIONADA_KEY);
            LocalStorage.RemoveItem(LocalStorageConstant.MATRICULAS_SELECIONADAS_KEY);
            LocalStorage.RemoveItem(LocalStorageConstant.ID_MATRICULAS_SELECIONADAS_KEY);
        }

        protected PenitenciariaDto PenitenciariaSelecionada
        {
            get => LocalStorage.ContainKey(LocalStorageConstant.PENITENCIARIA_SELECIONADA_KEY)
                ? LocalStorage.GetItem<PenitenciariaDto>(LocalStorageConstant.PENITENCIARIA_SELECIONADA_KEY)
                : null;

            set => LocalStorage.SetItem(LocalStorageConstant.PENITENCIARIA_SELECIONADA_KEY, value);
        }

        protected MatriculaDto MatriculaSelecionada
        {
            get => LocalStorage.ContainKey(LocalStorageConstant.MATRICULA_SELECIONADA_KEY)
                ? LocalStorage.GetItem<MatriculaDto>(LocalStorageConstant.MATRICULA_SELECIONADA_KEY)
                : null;

            set => LocalStorage.SetItem(LocalStorageConstant.MATRICULA_SELECIONADA_KEY, value);
        }

        protected List<MatriculaDto> MatriculasSelecionadas
        {
            get => LocalStorage.ContainKey(LocalStorageConstant.MATRICULAS_SELECIONADAS_KEY)
                ? LocalStorage.GetItem<List<MatriculaDto>>(LocalStorageConstant.MATRICULAS_SELECIONADAS_KEY)
                : null;

            set => LocalStorage.SetItem(LocalStorageConstant.MATRICULAS_SELECIONADAS_KEY, value);
        }

        protected List<int> IdMatriculasSelecionadas
        {
            get => LocalStorage.ContainKey(LocalStorageConstant.ID_MATRICULAS_SELECIONADAS_KEY)
                ? LocalStorage.GetItem<List<int>>(LocalStorageConstant.ID_MATRICULAS_SELECIONADAS_KEY)
                : null;

            set => LocalStorage.SetItem(LocalStorageConstant.ID_MATRICULAS_SELECIONADAS_KEY, value);
        }

        public void Dispose()
        {
            State.OnChange -= StateHasChanged;
        }
    }
}
