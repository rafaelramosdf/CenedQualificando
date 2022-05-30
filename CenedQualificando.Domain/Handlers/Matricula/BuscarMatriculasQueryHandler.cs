using AutoMapper;
using CenedQualificando.Domain.Models.Dtos;
using CenedQualificando.Domain.Models.Enumerations.Filters;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.Matricula;

public interface IBuscarMatriculasQueryHandler : IEnumerableQueryHandler<MatriculaDto, MatriculaFilter>
{
}

public class BuscarMatriculasQueryHandler : IBuscarMatriculasQueryHandler
{
    private readonly ILogger<BuscarMatriculasQueryHandler> Logger;
    private readonly IMatriculaQuery Query;
    private readonly IMatriculaRepository Repository;
    private readonly IMapper Mapper;

    public BuscarMatriculasQueryHandler(
        IMatriculaQuery query,
        IMatriculaRepository repository,
        IMapper mapper,
        ILogger<BuscarMatriculasQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public IEnumerable<MatriculaDto> Execute(MatriculaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler BuscarMatriculasQueryHandler");

        var queryList = Repository.List(Query.Filtrar(filtro));

        if (filtro != null)
        {
            if (filtro.TipoFiltroPersonalizado != MatriculaFilterEnum.Null)
                queryList = queryList.Where(Query.FiltrarPelaSituacaoDaMatricula(filtro.TipoFiltroPersonalizado));

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

        queryList = queryList.Take(filtro.Limit ?? 100);

        var dtoList = Mapper.Map<IEnumerable<Models.Entities.Matricula>, IEnumerable<MatriculaDto>>(queryList.ToList());

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
