using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class CursoService : ICursoService
    {
        private ICursoRefitService _refitService;

        public CursoService()
        {
            _refitService = RestService.For<ICursoRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<CursoDto>> Filtrar(DataTableModel<CursoDto> dataTableModel)
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
