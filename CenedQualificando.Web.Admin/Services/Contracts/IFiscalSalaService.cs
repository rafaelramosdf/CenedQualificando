using CenedQualificando.Web.Admin.Models;
using CenedQualificando.Web.Admin.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts
{
    public interface IFiscalSalaService
    {
        public Task<IEnumerable<FiscalSalaModel>> Listar();
        public Task<DataTableModel<FiscalSalaModel>> Filtrar(DataTableModel<FiscalSalaModel> dataTableModel);
    }
}
