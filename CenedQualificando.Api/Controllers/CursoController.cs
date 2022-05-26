﻿using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/cursos")]
    public class CursoController : BaseController<Curso, CursoDto, CursoFilter, ICursoService>
    {
        public CursoController(ICursoService service)
        : base(service)
        {
        }
    }
}
