using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface ICursoService
    {
        public Task<DataTableModel<CursoDto>> Filtrar(DataTableModel<CursoDto> dataTableModel);
    }
}
