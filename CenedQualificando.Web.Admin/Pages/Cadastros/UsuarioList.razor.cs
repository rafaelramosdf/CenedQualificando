﻿using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class UsuarioList : ListPageBase<Usuario, UsuarioFilter, UsuarioViewModel, IUsuarioApiService>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Usuários do Sistema / Lista";
        }
    }
}
