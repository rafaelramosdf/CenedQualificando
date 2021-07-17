﻿using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class FiscalSalaForm : FormPageBase<FiscalSala, FiscalSalaDto, IFiscalSalaApiService>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Fiscais de Sala / Novo";
            BackRoute = "/cadastros/fiscais-salas";
        }
    }
}