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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Api.Services
{
    public class ProvaService
        : BaseService<Prova, ProvaDto, ProvaFilter, IProvaQuery, IProvaRepository>, IProvaService
    {
        public ProvaService(
            IProvaQuery query,
            IProvaRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<ProvaService> log) :
            base(query, repository, unitOfWork, mapper, log)
        {
        }

        public async Task<IEnumerable<ProvaDto>> BuscarProvasPorIdMatriculas(int[] idMatriculas)
        {
            return Mapper.Map<IEnumerable<ProvaDto>>(await Repository.BuscarProvasPorIdMatriculas(idMatriculas));
        }
    }
}
