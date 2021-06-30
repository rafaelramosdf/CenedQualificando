using AutoMapper;
using CenedQualificando.Api.Services.Base;
using CenedQualificando.Domain.Interfaces.Queries;
using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Api.Services.Contracts;
using CenedQualificando.Domain.Interfaces.UoW;
using CenedQualificando.CrossCutting.Dtos;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations.Filters;
using CenedQualificando.Domain.Models.Filters;
using Microsoft.EntityFrameworkCore;
using System;
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

            if (filtro != null)
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

                if (filtro.PeriodoDataMatricula.Inicio.HasValue)
                    queryList = queryList.Where(x => x.DataMatricula >= filtro.PeriodoDataMatricula.Inicio);
                if (filtro.PeriodoDataMatricula.Final.HasValue)
                    queryList = queryList.Where(x => x.DataMatricula <= filtro.PeriodoDataMatricula.Final);

                if (filtro.PeriodoDataPiso.Inicio.HasValue)
                    queryList = queryList.Where(x => x.DataPiso >= filtro.PeriodoDataPiso.Inicio);
                if (filtro.PeriodoDataPiso.Final.HasValue)
                    queryList = queryList.Where(x => x.DataPiso <= filtro.PeriodoDataPiso.Final);

                if (filtro.PeriodoDataCertificadoExpedido.Inicio.HasValue)
                    queryList = queryList.Where(x => x.CertificadoExpedido >= filtro.PeriodoDataCertificadoExpedido.Inicio);
                if (filtro.PeriodoDataCertificadoExpedido.Final.HasValue)
                    queryList = queryList.Where(x => x.CertificadoExpedido <= filtro.PeriodoDataCertificadoExpedido.Final);

                if (filtro.PeriodoDataProvaRecebida.Inicio.HasValue || filtro.PeriodoDataProvaRecebida.Final.HasValue)
                {
                    var dtInicioProvaRecebida = filtro.PeriodoDataProvaRecebida.Inicio ?? DateTime.MinValue;
                    var dtFinalProvaRecebida = filtro.PeriodoDataProvaRecebida.Final ?? DateTime.MaxValue;
                    queryList = queryList.Where(x => x.Provas.Where(p => p.DataRecebidaProva >= dtInicioProvaRecebida
                                                    && p.DataRecebidaProva <= dtFinalProvaRecebida).Any());
                }
            }

            queryList = queryList
                .Include(i => i.Aluno)
                .Include(i => i.Curso).ThenInclude(i => i.ImpressaoCertificado)
                .Include(i => i.Provas)
                .AsSplitQuery();

            queryList = queryList.OrderByDescending(o => o.DataMatricula);

            queryList = queryList.Take(100); // TODO: Implementar paginação parametrizada

            var dtoList = Mapper.Map<IEnumerable<Matricula>, IEnumerable<MatriculaDto>>(queryList.ToList());

            if (filtro.PeriodoDataProvaRecebida.Inicio.HasValue || filtro.PeriodoDataProvaRecebida.Final.HasValue)
            {
                var dtInicioProvaRecebida = filtro.PeriodoDataProvaRecebida.Inicio ?? DateTime.MinValue;
                var dtFinalProvaRecebida = filtro.PeriodoDataProvaRecebida.Final ?? DateTime.MaxValue;
                dtoList = dtoList.Where(x => x.UltimaProvaRealizada != null
                            && x.UltimaProvaRealizada.DataRecebidaProva >= dtInicioProvaRecebida
                            && x.UltimaProvaRealizada.DataRecebidaProva <= dtFinalProvaRecebida);
            }

            return dtoList;
        }
    }
}
