using CenedQualificando.Api.Controllers.Base;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CenedQualificando.Api.Controllers
{
    [Route("api/alunos")]
    public class AlunoController : BaseController<Aluno, AlunoDto, IAlunoService>
    {
        public AlunoController(IAlunoService service)
        : base(service)
        {
        }
    }
}
