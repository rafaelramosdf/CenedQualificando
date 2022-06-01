using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Web.Admin.Services.ApiContracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class AtaProvaImpressao : DocumentPrintPageBase
    {
        [Inject] protected IDocumentoConsultaApiContract ConsultaApiService { get; set; }

        private List<MatriculaViewModel> ListaMatriculas = new List<MatriculaViewModel>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            ListaMatriculas = (List<MatriculaViewModel>) await ConsultaApiService.Matriculas(new MatriculaFilter 
            { 
                IdMatriculas = (IEnumerable<int?>)IdMatriculasSelecionadas 
            });
        }
    }
}
