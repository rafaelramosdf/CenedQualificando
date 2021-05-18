using CenedQualificando.Web.Admin.Models;
using CenedQualificando.Web.Admin.Models.Base;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IFiscalSalaRefitService
    {
        [Get("/fiscais-salas")]
        Task<IEnumerable<FiscalSalaModel>> Listar();

        [Post("/fiscais-salas/filtros")]
        Task<DataTableModel<FiscalSalaModel>> Filtrar([Body] DataTableModel<FiscalSalaModel> dataTableModel);
    }
}
