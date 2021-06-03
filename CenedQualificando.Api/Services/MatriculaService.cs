using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Services;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations.Filters;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Api.Services
{
    public class MatriculaService
        : BaseService<Matricula, MatriculaDto, IMatriculaQuery, IMatriculaRepository>, IMatriculaService
    {
        public MatriculaService(
            IMatriculaQuery query,
            IMatriculaRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper) :
            base(query, repository, unitOfWork, mapper)
        {
        }

        public override IQueryable<Matricula> CriarConsulta()
        {
            return Repository.List().Include(x => x.Aluno).Include(x => x.Curso);
        }

        public IEnumerable<MatriculaDto> Filtrar(MatriculaFilter filtro)
        {
            var queryList = Repository.List();

            if(filtro != null)
            {
                if (filtro.TipoFiltroPersonalizado != MatriculaFilterEnum.Null)
                    queryList = queryList.Where(Query.FiltroPersonalizado(filtro.TipoFiltroPersonalizado));

                if (filtro.IdAluno > 0)
                    queryList = queryList.Where(x => x.IdAluno == filtro.IdAluno);

                if (filtro.IdPenitenciaria > 0)
                    queryList = queryList.Where(x => x.IdPenitenciaria == filtro.IdPenitenciaria);

                if (filtro.IdMatriculas.Any())
                    queryList = queryList.Where(x => filtro.IdMatriculas.Contains(x.IdMatricula));

                if (filtro.StatusCurso.Any())
                    queryList = queryList.Where(x => filtro.StatusCurso.Contains(x.StatusCurso));

                if (filtro.PeriodoDataMatricula.HasValue)
                    queryList = queryList.Where(x => x.DataMatricula >= filtro.PeriodoDataMatricula.Inicio && x.DataMatricula <= filtro.PeriodoDataMatricula.Final);

                if(filtro.PeriodoDataPiso.HasValue)
                    queryList = queryList.Where(x => x.DataPiso >= filtro.PeriodoDataPiso.Inicio && x.DataPiso <= filtro.PeriodoDataPiso.Final);
            }

            queryList = queryList.Include(i => i.Aluno).Include(i => i.Curso);

            queryList = queryList.OrderByDescending(o => o.DataMatricula);

            queryList = queryList.Take(100); // TODO: Implementar paginação parametrizada

            return Mapper.Map<IEnumerable<Matricula>, IEnumerable<MatriculaDto>>(queryList.ToList());
        }
    }
}
