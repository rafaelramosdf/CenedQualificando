using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface ICargaHorariaDiariaService
    {
        public Task<DataTableModel<CargaHorariaDiariaDto>> Filtrar(DataTableModel<CargaHorariaDiariaDto> dataTableModel);
    }
}
