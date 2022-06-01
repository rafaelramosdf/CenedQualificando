using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class Declaracao : DocumentPageBase
    {
        [Inject] protected IDocumentoConsultaApiService ConsultaApiService { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }

        private IEnumerable<MatriculaViewModel> Lista = new List<MatriculaViewModel>();

        private HashSet<MatriculaViewModel> Selecionados { get; set; }

        private MatriculaFilter Filtro = new MatriculaFilter();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            State.TituloPagina = "Documentos / Declaração";
        }

        protected async Task Buscar()
        {
            State.Carregando = true;

            switch (TipoDeclaracao)
            {
                case TipoDeclaracaoEnum.DeclaracaoCursosConcluidos:
                    Filtro.StatusCurso = new List<int> 
                    { 
                        StatusCursoEnum.Aprovado.ToInt32() 
                    };
                    break;
                case TipoDeclaracaoEnum.DeclaracaoCursoEmAndamento:
                    Filtro.StatusCurso = new List<int>
                    {
                        StatusCursoEnum.EmAndamento.ToInt32(),
                        StatusCursoEnum.NaoAprovado.ToInt32(),
                        StatusCursoEnum.ReProva.ToInt32()
                    };
                    break;
            }

            Lista = await ConsultaApiService.Matriculas(Filtro);
            
            State.Carregando = false;
        }

        private string FilterString = "";
        private bool FilterFunc(MatriculaViewModel element)
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

        private void OnAlunoSelected(AlunoViewModel aluno)
        {
            AlunoSelecionado = aluno;
        }

        private void Imprimir()
        {
            if (Selecionados != null && Selecionados.Any())
            {
                IdMatriculasSelecionadas = Selecionados.Select(s => s.Id).ToList();
                OpenRoute("/documentos/declaracao/impressao", true);
            }
            else
            {
                Snackbar.Add("Selecione pelo menos uma Matrícula!");
            }
        }
    }
}
