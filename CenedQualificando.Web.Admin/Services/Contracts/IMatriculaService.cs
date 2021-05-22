using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IMatriculaService
    {
        public Task<DataTableModel<MatriculaDto>> Filtrar(DataTableModel<MatriculaDto> dataTableModel);
    }
}
