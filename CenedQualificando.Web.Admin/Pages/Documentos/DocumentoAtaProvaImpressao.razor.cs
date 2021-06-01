using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class DocumentoAtaProvaImpressao : PageBase
    {
        [Inject] IJSRuntime JSRun { get; set; }

        private DateTime DataRealizacaoProva = DateTime.Now;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Delay(2500);
                await JSRun.InvokeAsync<object>("print", null);
            }
        }
    }
}
