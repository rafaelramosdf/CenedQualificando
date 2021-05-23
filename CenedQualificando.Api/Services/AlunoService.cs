using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenedQualificando.Api.Services
{
    public class AlunoService
        : BaseService<Aluno, AlunoDto, IAlunoQuery, IAlunoRepository>, IAlunoService
    {
        public AlunoService(
            IAlunoQuery query,
            IAlunoRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper) :
            base(query, repository, unitOfWork, mapper)
        {
        }

        public override IQueryable<Aluno> CriarConsulta()
        {
            return Repository.List().Include(x => x.Penitenciaria);
        }

        public async Task<IEnumerable<Aluno>> BuscarAlunosPorId(int[] idAlunos)
        {
            return await Repository.BuscarAlunosPorId(idAlunos);
        }
    }
}
