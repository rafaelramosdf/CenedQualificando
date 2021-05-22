using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class PermissaoService : IPermissaoService
    {
        private IPermissaoRefitService _refitService;

        public PermissaoService()
        {
            _refitService = RestService.For<IPermissaoRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<PermissaoDto>> Filtrar(DataTableModel<PermissaoDto> dataTableModel)
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
