using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IProvaService : IBaseService<Prova, ProvaViewModel, ProvaFilter>
    {
        Task<IEnumerable<ProvaViewModel>> BuscarProvasPorIdMatriculas(int[] idMatriculas);
    }
}
