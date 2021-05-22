﻿using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class MatriculaList : ListPageBase<MatriculaDto>
    {
        [Inject] protected IMatriculaService MatriculaService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Matriculas / Lista";
            SomenteLeitura = true;
        }

        protected override async Task<DataTableModel<MatriculaDto>> Buscar(DataTableModel<MatriculaDto> dataTable)
        {
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await MatriculaService.Filtrar(dataTable);
            return dataTable;
        }

        protected MudBlazor.Color ObterClasseStatusCurso(StatusCursoEnum status)
        {
            switch (status)
            {
                case StatusCursoEnum.EmAndamento:
                    return MudBlazor.Color.Success;
                case StatusCursoEnum.Aprovado:
                    return MudBlazor.Color.Primary;
                case StatusCursoEnum.NaoAprovado:
                    return MudBlazor.Color.Warning;
                case StatusCursoEnum.Agendado:
                    return MudBlazor.Color.Info;
                case StatusCursoEnum.ReProva:
                    return MudBlazor.Color.Error;
                default:
                    return MudBlazor.Color.Dark;
            }
        }
    }
}