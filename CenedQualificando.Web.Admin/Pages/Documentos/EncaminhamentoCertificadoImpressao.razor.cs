using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class EncaminhamentoCertificadoImpressao : DocumentPrintPageBase
    {
        [Inject] protected IConsultaApiService ConsultaApiService { get; set; }

        private List<MatriculaDto> ListaMatriculas = new List<MatriculaDto>();

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            ListaMatriculas = (List<MatriculaDto>)await ConsultaApiService.Matriculas(new MatriculaFilter
            {
                IdMatriculas = IdMatriculasSelecionadas
            });
        }
    }
}