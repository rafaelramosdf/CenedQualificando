using System.Collections.Generic;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;

namespace CenedQualificando.Api.Services.Base
{
    public interface IFiscalSalaService
    {
        public IEnumerable<FiscalSalaDto> Listar();
        public DataTableModel<FiscalSalaDto> Listar(DataTableModel<FiscalSalaDto> dataTableModel);
    }
}
