using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class RepresentanteService : IRepresentanteService
    {
        private IRepresentanteRefitService _refitService;

        public RepresentanteService()
        {
            _refitService = RestService.For<IRepresentanteRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<RepresentanteDto>> Filtrar(DataTableModel<RepresentanteDto> dataTableModel)
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
