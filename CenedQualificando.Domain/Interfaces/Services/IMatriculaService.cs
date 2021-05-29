using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IMatriculaService : IBaseService<Matricula, MatriculaDto>
    {
        IEnumerable<MatriculaDto> Filtrar(MatriculaFilter filtro);
    }
}
