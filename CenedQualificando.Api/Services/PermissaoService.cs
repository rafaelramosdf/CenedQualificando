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
    public class PermissaoService
        : BaseService<Permissao, PermissaoDto, PermissaoFilter, IPermissaoQuery, IPermissaoRepository>, IPermissaoService
    {
        public PermissaoService(
            IPermissaoQuery query,
            IPermissaoRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<PermissaoService> log) :
            base(query, repository, unitOfWork, mapper, log)
        {
        }

        public void Attach(Permissao obj)
        {
            Repository.Attach(obj);
        }
    }
}
