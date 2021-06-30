using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System.Collections.Generic;

namespace CenedQualificando.Api.Services.Contracts
{
    public interface IMatriculaService : IBaseService<Matricula, MatriculaDto>
    {
        IEnumerable<MatriculaDto> Filtrar(MatriculaFilter filtro);
    }
}
