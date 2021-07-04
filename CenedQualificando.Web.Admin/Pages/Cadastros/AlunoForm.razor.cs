using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Utils;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq;
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

            if (!IsNewRegister)
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

        protected async Task OnSubmit(EditContext context)
        {
            //FormValid = context.Validate();

            //if (!FormValid)
            //{
            //    Alert(MudBlazor.Severity.Error, context.GetValidationMessages().ToList());
            //    return;
            //}
            
            var apiCommandResult = new CommandResult();

            apiCommandResult = IsNewRegister 
                ? await AlunoApiService.Incluir(Model) 
                : await AlunoApiService.Alterar((int)Id, Model);

            if (apiCommandResult.HasError)
            {
                Alert(MudBlazor.Severity.Error, apiCommandResult.Errors.ToList());
                return;
            }

            OpenRoute("/cadastros/alunos");
            Alert(MudBlazor.Severity.Success, "Dados salvos com sucesso!");

            StateHasChanged();
        }
    }
}
