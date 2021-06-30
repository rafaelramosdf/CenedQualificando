using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Api.Services
{
    public class RepresentanteService
        : BaseService<Representante, RepresentanteDto, IRepresentanteQuery, IRepresentanteRepository>, IRepresentanteService
    {
        public RepresentanteService(
            IRepresentanteQuery query,
            IRepresentanteRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper) :
            base(query, repository, unitOfWork, mapper)
        {
        }
    }
}
