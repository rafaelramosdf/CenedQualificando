using CenedQualificando.Web.Admin.Models;
using CenedQualificando.Web.Admin.Models.Base;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class FiscalSalaService : IFiscalSalaService
    {
        private IFiscalSalaRefitService _refitService;

        public FiscalSalaService()
        {
            _refitService = RestService.For<IFiscalSalaRefitService>("https://localhost:6001/api");
        }

        public async Task<IEnumerable<FiscalSalaModel>> Listar()
        {
            try
            {
                return await _refitService.Listar();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<DataTableModel<FiscalSalaModel>> Filtrar(DataTableModel<FiscalSalaModel> dataTableModel)
        {
            try
            {
                return await _refitService.Filtrar(dataTableModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
