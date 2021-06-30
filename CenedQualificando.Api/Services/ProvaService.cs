using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Api.Services
{
    public class ProvaService
        : BaseService<Prova, ProvaDto, IProvaQuery, IProvaRepository>, IProvaService
    {
        public ProvaService(
            IProvaQuery query,
            IProvaRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper) :
            base(query, repository, unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<ProvaDto>> BuscarProvasPorIdMatriculas(int[] idMatriculas)
        {
            return Mapper.Map<IEnumerable<ProvaDto>>(await Repository.BuscarProvasPorIdMatriculas(idMatriculas));
        }
    }
}
