using CenedQualificando.Api.Models;
using CenedQualificando.Api.Models.Base;
using System.Collections.Generic;

namespace CenedQualificando.Api.Services.Base
{
    public interface IFiscalSalaService
    {
        public IEnumerable<FiscalSalaModel> Listar();
        public DataTableModel<FiscalSalaModel> Listar(DataTableModel<FiscalSalaModel> dataTableModel);
    }
}
