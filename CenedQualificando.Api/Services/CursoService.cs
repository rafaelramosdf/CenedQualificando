using AutoMapper;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Interfaces.Services;

namespace CenedQualificando.Api.Services
{
    public class CursoService
        : BaseService<Curso, CursoDto, ICursoQuery, ICursoRepository>, ICursoService
    {
        public CursoService(
            ICursoQuery query,
            ICursoRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper) :
            base(query, repository, unitOfWork, mapper)
        {
        }
    }
}
