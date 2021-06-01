using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class DocumentoAtaProva : PageBase
    {
        [Inject] protected IConsultaApiService ConsultaApiService { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        [Inject] IJSRuntime JSRun { get; set; }

        private IEnumerable<MatriculaDto> Lista = new List<MatriculaDto>();

        private HashSet<MatriculaDto> selecionados { get; set; }
        private HashSet<MatriculaDto> Selecionados { 
            get 
            {
                return selecionados;
            } 
            set 
            {
                selecionados = value;
                MatriculasSelecionadas = selecionados.ToList();
            } 
        }

        private void OnItemChanged(PenitenciariaDto penitenciaria)
        {
            PenitenciariaSelecionada = penitenciaria;
        }

        private MatriculaFilter Filtro = new MatriculaFilter();

        protected override void OnInit()
        {
            State.TituloPagina = "Documentos / Ata de Prova";
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
            if (MatriculasSelecionadas != null && MatriculasSelecionadas.Any())
            {
                JSRun.InvokeAsync<object>("open", new object[] { "/documentos/ata-prova/impressao", "_blank" });
            }
            else
            {
                Snackbar.Add("Selecione pelo menos uma Matrícula!");
            }
        }
    }
}
