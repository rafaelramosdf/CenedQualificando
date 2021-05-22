using System.Threading.Tasks;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IAlunoService
    {
        public Task<DataTableModel<AlunoDto>> Filtrar(DataTableModel<AlunoDto> dataTableModel);
    }
}
