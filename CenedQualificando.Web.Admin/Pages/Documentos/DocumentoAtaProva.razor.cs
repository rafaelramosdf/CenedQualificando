using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class DocumentoAtaProva : PageBase
    {
        [Inject] protected IConsultaApiService ConsultaApiService { get; set; }

        private IEnumerable<MatriculaDto> Lista = new List<MatriculaDto>();
        private HashSet<MatriculaDto> Selecionados = new HashSet<MatriculaDto>();

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
    }
}
