using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.Extensions.Logging;

namespace CenedQualificando.Api.Services
{
    public class CargaHorariaDiariaService
        : BaseService<CargaHorariaDiaria, CargaHorariaDiariaDto, CargaHorariaDiariaFilter, ICargaHorariaDiariaQuery, ICargaHorariaDiariaRepository>, ICargaHorariaDiariaService
    {
        public CargaHorariaDiariaService(
            ICargaHorariaDiariaQuery query,
            ICargaHorariaDiariaRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<CargaHorariaDiariaService> log) :
            base(query, repository, unitOfWork, mapper, log)
        {
        }
    }
}
