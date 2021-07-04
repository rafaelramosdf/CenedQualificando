using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class FormPageBase : PageBase 
    {
        [Parameter] public int? Id { get; set; }
        protected bool FormValid { get; set; } = false;

        protected bool IsNewRegister => Id == null;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Delay(2000);
                await JSRun.InvokeVoidAsync("setMaskInput");
            }
        }
    }
}
