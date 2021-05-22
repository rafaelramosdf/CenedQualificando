﻿using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.Contracts.RefitServices
{
    public interface IProvaRefitService
    {
        [Post("/provas/filtros")]
        Task<DataTableModel<ProvaDto>> Filtrar([Body] DataTableModel<ProvaDto> dataTableModel);
    }
}
