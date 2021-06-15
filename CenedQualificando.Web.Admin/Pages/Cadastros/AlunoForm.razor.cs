using CenedQualificando.Domain.Extensions;
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

        bool success;
        protected void OnValidSubmit(EditContext context)
        {
            success = true;
            StateHasChanged();
        }
    }
}
