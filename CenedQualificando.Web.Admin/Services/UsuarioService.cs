using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRefitService _refitService;

        public UsuarioService()
        {
            _refitService = RestService.For<IUsuarioRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<UsuarioDto>> Filtrar(DataTableModel<UsuarioDto> dataTableModel)
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
