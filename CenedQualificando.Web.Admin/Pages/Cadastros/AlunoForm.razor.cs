using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class AlunoForm : FormPageBase
    {
        [Inject] protected IAlunoApiService AlunoApiService { get; set; }

        private AlunoDto Model { get; set; } = new AlunoDto();
        
        protected override async Task OnInitializedAsync()
        {
            State.TituloPagina = "Alunos / Formulário";

            if (Id != null) 
            { 
                await GetModel();
            }
        }

        protected async Task GetModel()
        {
            State.Carregando = true;
            Model = await AlunoApiService.Buscar(Id.Value);
            State.Carregando = false;
        }

        protected void OnSubmit(EditContext context)
        {
            FormValid = context.Validate();

            if (FormValid)
            {
                OpenRoute("/cadastros/alunos");
                Alert(MudBlazor.Severity.Success, "Dados salvos com sucesso!");
            }
            else
            {
                Alert(MudBlazor.Severity.Error, $"Formulário inválido: <br />" +
                    $"• {string.Join("<br />• ", context.GetValidationMessages())}");
            }

            StateHasChanged();
        }
    }
}
