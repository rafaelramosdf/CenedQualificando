using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class ProvaService : IProvaService
    {
        private IProvaRefitService _refitService;

        public ProvaService()
        {
            _refitService = RestService.For<IProvaRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<ProvaDto>> Filtrar(DataTableModel<ProvaDto> dataTableModel)
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
