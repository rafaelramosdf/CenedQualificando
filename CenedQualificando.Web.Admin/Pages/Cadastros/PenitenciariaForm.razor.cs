﻿using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.ApiContracts;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class PenitenciariaForm : FormPageBase<Penitenciaria, PenitenciariaFilter, PenitenciariaViewModel, IPenitenciariaApiContract>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Penitenciárias / Novo";
            BackRoute = "/cadastros/penitenciarias";
        }
    }
}