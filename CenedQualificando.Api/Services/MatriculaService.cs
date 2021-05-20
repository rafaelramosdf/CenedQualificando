using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Api.Services
{
    public class MatriculaService
        : BaseService<Matricula, MatriculaDto, IMatriculaQuery, IMatriculaRepository>, IMatriculaService
    {
        private readonly IProvaRepository _provaRepository;
        private readonly IAlunoRepository _alunoRepository;

        public MatriculaService(
            IMatriculaQuery query,
            IMatriculaRepository repository,
            IProvaRepository provaRepository,
            IAlunoRepository alunoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper) :
            base(query, repository, unitOfWork, mapper)
        {
            _provaRepository = provaRepository;
            _alunoRepository = alunoRepository;
        }
    }
}
