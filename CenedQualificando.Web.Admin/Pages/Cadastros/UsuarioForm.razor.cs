﻿using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Web.Admin.Services.RefitApiServices;
using CenedQualificando.Web.Admin.Shared.CodeBase.Pages;

namespace CenedQualificando.Web.Admin.Pages.Cadastros
{
    public partial class UsuarioForm : FormPageBase<Usuario, UsuarioDto, IUsuarioApiService>
    {
        protected override void OnInit()
        {
            State.TituloPagina = "Usuários do Sistema / Novo";
            BackRoute = "/cadastros/usuarios";
        }
    }
}
