﻿using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/grupos-permissoes")]
    public class GrupoDePermissaoController : BaseController<GrupoDePermissao, GrupoDePermissaoDto, IGrupoDePermissaoService>
    {
        public GrupoDePermissaoController(IGrupoDePermissaoService service)
        : base(service)
        {
        }
    }
}
