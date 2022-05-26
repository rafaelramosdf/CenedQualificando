using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IProvaService : IBaseService<Prova, ProvaDto, ProvaFilter>
    {
        Task<IEnumerable<ProvaDto>> BuscarProvasPorIdMatriculas(int[] idMatriculas);
    }
}
