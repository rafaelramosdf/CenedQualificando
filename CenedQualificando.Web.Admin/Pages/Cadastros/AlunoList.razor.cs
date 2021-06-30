﻿using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Utils;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class AlunoList : ListPageBase<AlunoDto>
    {
        [Inject] protected IAlunoApiService AlunoApiService { get; set; }

        protected override void OnInit()
        {
            State.TituloPagina = "Alunos / Lista";
            SomenteLeitura = true;
        }
        
        protected override async Task<DataTableModel<AlunoDto>> Buscar(DataTableModel<AlunoDto> dataTable)
        {
            State.Carregando = true;
            dataTable.Filter.Text = FiltroTexto;
            dataTable = await AlunoApiService.Filtrar(dataTable);
            State.Carregando = false;
            return dataTable;
        }
    }
}
