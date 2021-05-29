﻿using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Objects;
using Refit;
using System.Threading.Tasks;

namespace CenedQualificando.Web.Admin.Services.RefitApiServices
{
    public interface ICargaHorariaDiariaApiService
    {
        [Post("/cargas-horarias-diarias/filtros")]
        Task<DataTableModel<CargaHorariaDiariaDto>> Filtrar([Body] DataTableModel<CargaHorariaDiariaDto> dataTableModel);
    }
}