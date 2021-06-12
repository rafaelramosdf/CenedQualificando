using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class PageBase : ComponentBase, IDisposable
    {
        [Inject] protected StateContainer State { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject] protected IJSRuntime JSRun { get; set; }

        protected virtual void OnInit() { }

        protected override void OnInitialized()
        {
            State.OnChange += StateHasChanged;
            OnInit();
        }

        protected void OpenRoute(string route, bool forceLoad = false)
        {
            NavigationManager.NavigateTo(route, forceLoad);
        }
        protected async Task OpenRouteInTab(string route)
        {
            await JSRun.InvokeAsync<object>("open", route, "_blank");
        }
        protected async Task OpenRouteInPopup(string route)
        {
            await JSRun.InvokeAsync<object>("open", route, "_blank", "width=800,height=600,toolbar=0,location=0,scrollbars=0,status=0");
        }

        public void Dispose()
        {
            State.OnChange -= StateHasChanged;
        }
    }
}
