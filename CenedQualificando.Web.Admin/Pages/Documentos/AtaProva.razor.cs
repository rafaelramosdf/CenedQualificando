﻿using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Enumerations.Filters;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Models.Utils;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Documentos
{
    public partial class AtaProva : DocumentPageBase
    {
        [Inject] protected IConsultaApiService ConsultaApiService { get; set; }
        [Inject] ISnackbar Snackbar { get; set; }
        [Inject] IJSRuntime JSRun { get; set; }

        private IEnumerable<MatriculaDto> Lista = new List<MatriculaDto>();

        private HashSet<MatriculaDto> Selecionados { get; set; }

        private void OnItemChanged(PenitenciariaDto penitenciaria)
        {
            PenitenciariaSelecionada = penitenciaria;
        }

        private MatriculaFilter Filtro = new MatriculaFilter 
        {
            TipoFiltroPersonalizado = MatriculaFilterEnum.SomenteMatriculaComProvaAutorizada,
            PeriodoDataPiso = new PeriodoData { Inicio = DateTime.Now, Final = DateTime.Now }
        };

        protected override void OnInitialized()
        {
            base.OnInitialized();
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
            if (Selecionados != null && Selecionados.Any())
            {
                IdMatriculasSelecionadas = Selecionados.Select(s => s.Id).ToList();
                JSRun.InvokeAsync<object>("open", new object[] { "/documentos/ata-prova/impressao", "_blank" });
            }
            else
            {
                Snackbar.Add("Selecione pelo menos uma Matrícula!");
            }
        }
    }
}