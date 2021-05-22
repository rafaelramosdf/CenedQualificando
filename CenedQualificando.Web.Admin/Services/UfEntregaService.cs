using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class UfEntregaService : IUfEntregaService
    {
        private IUfEntregaRefitService _refitService;

        public UfEntregaService()
        {
            _refitService = RestService.For<IUfEntregaRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<UfEntregaDto>> Filtrar(DataTableModel<UfEntregaDto> dataTableModel)
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
