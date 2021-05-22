using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IRepresentanteService
    {
        public Task<DataTableModel<RepresentanteDto>> Filtrar(DataTableModel<RepresentanteDto> dataTableModel);
    }
}
