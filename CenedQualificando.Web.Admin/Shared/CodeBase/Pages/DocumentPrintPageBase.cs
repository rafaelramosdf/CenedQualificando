using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class DocumentPrintPageBase : DocumentLocalStoragePageBase
    {
        [Inject] IJSRuntime JSRun { get; set; }

        protected bool Impresso = false;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1500);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (!firstRender && !Impresso)
            {
                Impresso = true;
                Imprimir();
            }
        }

        protected void Imprimir()
        {
            JSRun.InvokeAsync<object>("print", null);
        }
    }
}
