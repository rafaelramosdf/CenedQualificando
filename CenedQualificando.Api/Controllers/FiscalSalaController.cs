﻿using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/fiscais-salas")]
    public class FiscalSalaController : BaseController<FiscalSala, FiscalSalaDto, IFiscalSalaService>
    {
        public FiscalSalaController(IFiscalSalaService service)
        : base(service)
        {
        }
    }
}
