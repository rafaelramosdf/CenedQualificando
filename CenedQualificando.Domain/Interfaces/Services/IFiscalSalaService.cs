﻿using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IFiscalSalaService : IBaseService<FiscalSala, FiscalSalaDto, FiscalSalaFilter>
    {
    }
}
