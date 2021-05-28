using CenedQualificando.Domain.Models.Objects;
using CenedQualificando.Web.Admin.Services.Contracts;
using CenedQualificando.Web.Admin.Services.Contracts.RefitServices;
using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services
{
    public class ComboEntidadeService : IComboEntidadeService
    {
        private IComboEntidadeRefitService _refitService;

        public ComboEntidadeService()
        {
            _refitService = RestService.For<IComboEntidadeRefitService>("https://localhost:6001/api/combos/entidades");
        }

        public async Task<IEnumerable<SelectResult>> Penitenciarias(SelectSearchParam param)
        {
            try
            {
                return await _refitService.Penitenciarias(param);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
