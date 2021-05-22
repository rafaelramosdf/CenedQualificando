using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class PenitenciariaService : IPenitenciariaService
    {
        private IPenitenciariaRefitService _refitService;

        public PenitenciariaService()
        {
            _refitService = RestService.For<IPenitenciariaRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<PenitenciariaDto>> Filtrar(DataTableModel<PenitenciariaDto> dataTableModel)
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
