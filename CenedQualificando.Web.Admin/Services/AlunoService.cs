using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class AlunoService : IAlunoService
    {
        private IAlunoRefitService _refitService;

        public AlunoService()
        {
            _refitService = RestService.For<IAlunoRefitService>("https://localhost:6001/api");
        }

        public async Task<DataTableModel<AlunoDto>> Filtrar(DataTableModel<AlunoDto> dataTableModel)
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
