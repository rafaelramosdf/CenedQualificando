using Blazored.LocalStorage;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Enumerations;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class DocumentLocalStoragePageBase : ComponentBase, IDisposable
    {
        [Inject] protected StateContainer State { get; set; }
        [Inject] protected ISyncLocalStorageService LocalStorage { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            State.OnChange += StateHasChanged;
        }

        protected const string DATA_IMPRESSAO_DOCUMENTO_KEY = "DOC_DATA_IMPRESSAO";
        protected const string ALUNO_SELECIONADO_KEY = "DOC_ALUNO_SELECIONADO";
        protected const string PENITENCIARIA_SELECIONADA_KEY = "DOC_PENITENCIARIA_SELECIONADA";
        protected const string MATRICULA_SELECIONADA_KEY = "DOC_MATRICULA_SELECIONADA";
        protected const string MATRICULAS_SELECIONADAS_KEY = "DOC_MATRICULAS_SELECIONADAS";
        protected const string ID_MATRICULAS_SELECIONADAS_KEY = "DOC_ID_MATRICULAS_SELECIONADAS";
        protected const string TIPO_DECLARACAO_KEY = "DOC_TIPO_DECLARACAO";

        protected void LimparLocalStorage()
        {
            DataImpressaoDocumento = DateTime.Now;
            LocalStorage.RemoveItem(ALUNO_SELECIONADO_KEY);
            LocalStorage.RemoveItem(PENITENCIARIA_SELECIONADA_KEY);
            LocalStorage.RemoveItem(MATRICULA_SELECIONADA_KEY);
            LocalStorage.RemoveItem(MATRICULAS_SELECIONADAS_KEY);
            LocalStorage.RemoveItem(ID_MATRICULAS_SELECIONADAS_KEY);
            LocalStorage.RemoveItem(TIPO_DECLARACAO_KEY);
        }

        protected DateTime? DataImpressaoDocumento
        {
            get => LocalStorage.ContainKey(DATA_IMPRESSAO_DOCUMENTO_KEY)
                ? LocalStorage.GetItem<DateTime>(DATA_IMPRESSAO_DOCUMENTO_KEY)
                : null;

            set => LocalStorage.SetItem(DATA_IMPRESSAO_DOCUMENTO_KEY, value);
        }

        protected AlunoDto AlunoSelecionado
        {
            get => LocalStorage.ContainKey(ALUNO_SELECIONADO_KEY)
                ? LocalStorage.GetItem<AlunoDto>(ALUNO_SELECIONADO_KEY)
                : null;

            set => LocalStorage.SetItem(ALUNO_SELECIONADO_KEY, value);
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

        protected TipoDeclaracaoEnum TipoDeclaracao
        {
            get => LocalStorage.ContainKey(TIPO_DECLARACAO_KEY)
                ? LocalStorage.GetItem<TipoDeclaracaoEnum>(TIPO_DECLARACAO_KEY)
                : TipoDeclaracaoEnum.DeclaracaoCursosConcluidos;

            set => LocalStorage.SetItem(TIPO_DECLARACAO_KEY, value);
        }

        public void Dispose()
        {
            State.OnChange -= StateHasChanged;
        }
    }
}
