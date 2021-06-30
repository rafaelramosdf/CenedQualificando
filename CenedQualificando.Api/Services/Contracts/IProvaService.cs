using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Api.Services.Contracts
{
    public interface IProvaService : IBaseService<Prova, ProvaDto>
    {
        Task<IEnumerable<ProvaDto>> BuscarProvasPorIdMatriculas(int[] idMatriculas);
    }
}
