using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Api.Controllers.Select
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/combos/enumeradores")]
    public class SelectEnumController : Controller
    {
        [HttpGet("status-curso")]
        public ActionResult<SelectResult> StatusCurso(
            [FromQuery] SelectSearchParam param)
        {
            var list = new List<SelectResult>();

            var enumList = !string.IsNullOrEmpty(param.Term) 
                ? Enum.GetValues<StatusCursoEnum>().ToList().Where(x => x.EnumDescription().Contains(param.Term)).ToList()
                : Enum.GetValues<StatusCursoEnum>().ToList();

            foreach (var item in enumList)
            {
                list.Add(new SelectResult 
                {
                    Id = item.ToInt32(),
                    Text = item.EnumDescription()
                });
            }

            return Ok(list);
        }
    }
}
