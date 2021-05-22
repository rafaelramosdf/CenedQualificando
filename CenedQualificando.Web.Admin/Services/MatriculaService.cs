using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class MatriculaService : IMatriculaService
    {
        private IMatriculaRefitService _refitService;

        public MatriculaService()
        {
            _refitService = RestService.For<IMatriculaRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<MatriculaDto>> Filtrar(DataTableModel<MatriculaDto> dataTableModel)
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
