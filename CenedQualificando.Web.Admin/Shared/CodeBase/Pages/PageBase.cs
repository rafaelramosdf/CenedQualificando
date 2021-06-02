using Microsoft.AspNetCore.Components;
using System;

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

        public void Dispose()
        {
            State.OnChange -= StateHasChanged;
        }
    }
}
