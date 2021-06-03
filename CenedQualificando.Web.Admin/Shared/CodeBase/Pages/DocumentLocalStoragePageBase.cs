using Blazored.LocalStorage;
using CenedQualificando.Domain.Models.Dtos;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class DocumentLocalStoragePageBase : ComponentBase, IDisposable
    {
        [Inject] protected StateContainer State { get; set; }
        [Inject] protected ISyncLocalStorageService LocalStorage { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            State.OnChange += StateHasChanged;
        }

        protected const string DATA_IMPRESSAO_DOCUMENTO_KEY = "DataImpressaoDocumento";
        protected const string PENITENCIARIA_SELECIONADA_KEY = "PenitenciariaSelecionada";
        protected const string MATRICULA_SELECIONADA_KEY = "MatriculaSelecionada";
        protected const string MATRICULAS_SELECIONADAS_KEY = "MatriculasSelecionadas";
        protected const string ID_MATRICULAS_SELECIONADAS_KEY = "IdMatriculasSelecionadas";

        protected DateTime? DataImpressaoDocumento
        {
            get => LocalStorage.ContainKey(DATA_IMPRESSAO_DOCUMENTO_KEY)
                ? LocalStorage.GetItem<DateTime>(DATA_IMPRESSAO_DOCUMENTO_KEY)
                : null;

            set => LocalStorage.SetItem(DATA_IMPRESSAO_DOCUMENTO_KEY, value);
        }

        protected PenitenciariaDto PenitenciariaSelecionada
        {
            get => LocalStorage.ContainKey(PENITENCIARIA_SELECIONADA_KEY)
                ? LocalStorage.GetItem<PenitenciariaDto>(PENITENCIARIA_SELECIONADA_KEY)
                : null;

            set => LocalStorage.SetItem(PENITENCIARIA_SELECIONADA_KEY, value);
        }

        protected MatriculaDto MatriculaSelecionada
        {
            get => LocalStorage.ContainKey(MATRICULA_SELECIONADA_KEY)
                ? LocalStorage.GetItem<MatriculaDto>(MATRICULA_SELECIONADA_KEY)
                : null;

            set => LocalStorage.SetItem(MATRICULA_SELECIONADA_KEY, value);
        }

        protected List<MatriculaDto> MatriculasSelecionadas
        {
            get => LocalStorage.ContainKey(MATRICULAS_SELECIONADAS_KEY)
                ? LocalStorage.GetItem<List<MatriculaDto>>(MATRICULAS_SELECIONADAS_KEY)
                : null;

            set => LocalStorage.SetItem(MATRICULAS_SELECIONADAS_KEY, value);
        }

        protected List<int> IdMatriculasSelecionadas
        {
            get => LocalStorage.ContainKey(ID_MATRICULAS_SELECIONADAS_KEY)
                ? LocalStorage.GetItem<List<int>>(ID_MATRICULAS_SELECIONADAS_KEY)
                : null;

            set => LocalStorage.SetItem(ID_MATRICULAS_SELECIONADAS_KEY, value);
        }

        public void Dispose()
        {
            State.OnChange -= StateHasChanged;
        }
    }
}
