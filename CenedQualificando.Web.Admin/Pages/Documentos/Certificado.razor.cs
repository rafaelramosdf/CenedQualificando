using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class Certificado : DocumentPageBase
    {
        [Inject] protected IConsultaApiService ConsultaApiService { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }

        private IEnumerable<MatriculaDto> Lista = new List<MatriculaDto>();

        private MatriculaDto Selecionado { get; set; }

        private MatriculaFilter Filtro = new MatriculaFilter 
        {
            StatusCurso = new List<int> { StatusCursoEnum.Aprovado.ToInt32() }
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();
            State.TituloPagina = "Documentos / Certificado";
        }

        protected async Task Buscar()
        {
            State.Carregando = true;
            Lista = await ConsultaApiService.Matriculas(Filtro);
            State.Carregando = false;
        }

        private string FilterString = "";
        private bool FilterFunc(MatriculaDto element)
        {
            if (string.IsNullOrWhiteSpace(FilterString))
                return true;
            if (element.Aluno.Nome.Contains(FilterString))
                return true;
            if (element.Aluno.Cpf == FilterString)
                return true;
            if (element.Curso.Nome.Contains(FilterString))
                return true;
            if (element.Curso.Codigo == FilterString)
                return true;
            return false;
        }

        private void Imprimir()
        {
            if (Selecionado != null)
            {
                MatriculaSelecionada = Selecionado;
                NavigationManager.NavigateTo("/documentos/certificado/impressao");
            }
            else
            {
                Snackbar.Add("Selecione uma Matrícula!");
            }
        }
    }
}
