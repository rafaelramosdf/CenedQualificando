using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class GrupoDePermissaoService : IGrupoDePermissaoService
    {
        private IGrupoDePermissaoRefitService _refitService;

        public GrupoDePermissaoService()
        {
            _refitService = RestService.For<IGrupoDePermissaoRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<GrupoDePermissaoDto>> Filtrar(DataTableModel<GrupoDePermissaoDto> dataTableModel)
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
