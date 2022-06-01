using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Web.Admin.Services.ApiContracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class EncaminhamentoMaterial : DocumentPageBase
    {
        [Inject] protected IDocumentoConsultaApiContract ConsultaApiService { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }

        private IEnumerable<MatriculaViewModel> Lista = new List<MatriculaViewModel>();

        private HashSet<MatriculaViewModel> Selecionados { get; set; }

        private void OnPenitenciariaSelected(PenitenciariaViewModel penitenciaria)
        {
            PenitenciariaSelecionada = penitenciaria;
        }

        private MatriculaFilter Filtro = new MatriculaFilter
        {
            StatusCurso = new List<int?> { StatusCursoEnum.EmAndamento.ToInt32() }
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();
            State.TituloPagina = "Documentos / Encaminhamento de Material";
        }

        protected async Task Buscar()
        {
            State.Carregando = true;
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

        private void Imprimir()
        {
            if (Selecionados != null && Selecionados.Any())
            {
                IdMatriculasSelecionadas = Selecionados.Select(s => s.Id).ToList();
                OpenRoute("/documentos/encaminhamento-material/impressao", true);
            }
            else
            {
                Snackbar.Add("Selecione pelo menos uma Matrícula!");
            }
        }
    }
}