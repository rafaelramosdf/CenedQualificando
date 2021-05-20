using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IProvaService : IBaseService<Prova, ProvaDto>
    {
        Task<IEnumerable<ProvaDto>> BuscarProvasPorIdMatriculas(int[] idMatriculas);
    }
}
