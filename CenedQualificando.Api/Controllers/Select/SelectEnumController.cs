using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Models.Utils;
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
        public ActionResult<SelectResult> StatusCurso([FromQuery] SelectSearchParam param)
        {
            return Ok(ObterListaEnumeradores<StatusCursoEnum>(param));
        }

        private IEnumerable<SelectResult> ObterListaEnumeradores<TEnum>(SelectSearchParam param)
            where TEnum : struct, Enum
        {
            var list = new List<SelectResult>();

            list = !string.IsNullOrEmpty(param.Term)
                ? Enum.GetValues<TEnum>().ToList()
                    .Where(x => x.EnumDescription().Contains(param.Term))
                    .Select(s => new SelectResult { Id = s.ToInt32(), Text = s.EnumDescription() })
                    .ToList()
                : Enum.GetValues<TEnum>()
                    .Select(s => new SelectResult { Id = s.ToInt32(), Text = s.EnumDescription() })
                    .ToList();

            return list;
        }
    }
}
