using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Api.Controllers.v1
{
    [ApiController]
    [AllowAnonymous]
    [Produces("application/json")]
    [Route("api/v1/combos/enumeradores")]
    public class ComboSelecaoEnumeradorController : Controller
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
