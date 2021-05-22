using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class CargaHorariaDiariaService : ICargaHorariaDiariaService
    {
        private ICargaHorariaDiariaRefitService _refitService;

        public CargaHorariaDiariaService()
        {
            _refitService = RestService.For<ICargaHorariaDiariaRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<CargaHorariaDiariaDto>> Filtrar(DataTableModel<CargaHorariaDiariaDto> dataTableModel)
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
