using CenedQualificando.Domain.Models.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class PageBase : ComponentBase, IDisposable
    {
        [Inject] protected StateContainer State { get; set; }
        [Inject] Blazored.LocalStorage.ISyncLocalStorageService LocalStorage { get; set; }

        protected virtual void OnInit() { }

        protected override void OnInitialized()
        {
            State.OnChange += StateHasChanged;
            OnInit();
        }

        protected PenitenciariaDto PenitenciariaSelecionada
        {
            get => LocalStorage.ContainKey("PenitenciariaSelecionada")
                ? LocalStorage.GetItem<PenitenciariaDto>("PenitenciariaSelecionada")
                : null;

            set => LocalStorage.SetItem("PenitenciariaSelecionada", value);
        }

        protected MatriculaDto MatriculaSelecionada
        {
            get => LocalStorage.ContainKey("MatriculaSelecionada")
                ? LocalStorage.GetItem<MatriculaDto>("MatriculaSelecionada")
                : null;

            set => LocalStorage.SetItem("MatriculaSelecionada", value);
        }

        protected List<MatriculaDto> MatriculasSelecionadas
        {
            get => LocalStorage.ContainKey("MatriculasSelecionadas")
                ? LocalStorage.GetItem<List<MatriculaDto>>("MatriculasSelecionadas")
                : null;

            set => LocalStorage.SetItem("MatriculasSelecionadas", value);
        }

        public void Dispose()
        {
            State.OnChange -= StateHasChanged;
        }
    }
}
