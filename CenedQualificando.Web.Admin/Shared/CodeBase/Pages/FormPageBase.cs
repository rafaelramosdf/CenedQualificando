using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Utils;
using CenedQualificando.Web.Admin.Services.RefitApiServices.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Shared.CodeBase.Pages
{
    public abstract partial class FormPageBase<TEntity, TDto, TApiService> : PageBase
        where TEntity : Entity 
        where TDto : Dto<TEntity> 
        where TApiService : ICRUDService<TEntity, TDto>
    {
        [Inject] protected ILogger<FormPageBase<TEntity, TDto, TApiService>> Log { get; set; }
        [Inject] protected TApiService ApiService { get; set; }
        [Inject] protected IDialogService Dialog { get; set; }

        [Parameter] public int? Id { get; set; }
        protected bool FormValid { get; set; } = false;

        protected bool IsNewRegister => Id == null;
        protected string BackRoute { get; set; }
        protected TDto Model { get; set; } = Activator.CreateInstance<TDto>();

        protected override async Task OnInitializedAsync()
        {
            if (!IsNewRegister)
            {
                await GetModel();
            }

            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.Delay(2500);
                await JSRun.InvokeVoidAsync("setMaskInput");
            }
        }

        protected async Task GetModel()
        {
            State.Carregando = true;
            Model = await ApiService.Buscar(Id.Value);
            State.Carregando = false;
        }

        protected async Task OnSubmit(EditContext context)
        {
            FormValid = context.Validate();

            if (!FormValid)
            {
                Alert(Severity.Error, context.GetValidationMessages().ToList());
                return;
            }

            CommandResult apiResponse;

            apiResponse = IsNewRegister
                ? await ApiService.Incluir(Model)
                : await ApiService.Alterar((int)Id, Model);

            if (apiResponse == null || apiResponse.HasError)
            {
                Alert(Severity.Error, apiResponse.Errors.ToList());
                return;
            }

            OpenRoute(BackRoute);
            Alert(Severity.Success, "Dados salvos com sucesso!");
            StateHasChanged();
        }
    }
}
