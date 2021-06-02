using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class DocumentoAtaProvaImpressao : PrintPageBase
    {
        [Inject] protected IConsultaApiService ConsultaApiService { get; set; }

        private DateTime DataRealizacaoProva = DateTime.Now;
        private List<MatriculaDto> ListaMatriculas = new List<MatriculaDto>();

        protected override async Task OnInitializedAsync()
        {
            State.Carregando = true;

            ListaMatriculas = (List<MatriculaDto>) await ConsultaApiService.Matriculas(new MatriculaFilter 
            { 
                IdMatriculas = IdMatriculasSelecionadas 
            });

            State.Carregando = false;
        }
    }
}
