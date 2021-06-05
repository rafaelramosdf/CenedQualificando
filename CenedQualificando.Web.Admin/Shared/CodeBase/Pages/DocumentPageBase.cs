using System;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class DocumentPageBase : DocumentLocalStoragePageBase
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();

            DataImpressaoDocumento = DateTime.Now;
            LocalStorage.RemoveItem(ALUNO_SELECIONADO_KEY);
            LocalStorage.RemoveItem(PENITENCIARIA_SELECIONADA_KEY);
            LocalStorage.RemoveItem(MATRICULA_SELECIONADA_KEY);
            LocalStorage.RemoveItem(MATRICULAS_SELECIONADAS_KEY);
            LocalStorage.RemoveItem(ID_MATRICULAS_SELECIONADAS_KEY);
            LocalStorage.RemoveItem(TIPO_DECLARACAO_KEY);
        }
    }
}
