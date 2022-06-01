using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface ICargaHorariaDiariaService : IBaseService<CargaHorariaDiaria, CargaHorariaDiariaViewModel, CargaHorariaDiariaFilter>
    {
    }
}
