using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.Matricula;

public interface IObterDocumentoConsultaMatriculasQueryHandler : IEnumerableQueryHandler<MatriculaViewModel, MatriculaFilter>
{
}

public class ObterDocumentoConsultaMatriculasQueryHandler : IObterDocumentoConsultaMatriculasQueryHandler
{
    private readonly ILogger<ObterDocumentoConsultaMatriculasQueryHandler> Logger;
    private readonly IMatriculaQuery Query;
    private readonly IMatriculaRepository Repository;
    private readonly IMapper Mapper;

    public ObterDocumentoConsultaMatriculasQueryHandler(
        IMatriculaQuery query,
        IMatriculaRepository repository,
        IMapper mapper,
        ILogger<ObterDocumentoConsultaMatriculasQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public IEnumerable<MatriculaViewModel> Execute(MatriculaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterDocumentoConsultaMatriculasQueryHandler");

        var queryList = Repository.List(Query.ObterPesquisa(filtro));

        queryList = Query.FiltrarMatriculas(filtro, queryList);

        queryList = queryList
            .Include(i => i.Aluno)
            .Include(i => i.Curso).ThenInclude(i => i.ImpressaoCertificado)
            .Include(i => i.Provas)
            .AsSplitQuery();

        queryList = queryList.OrderByDescending(o => o.DataMatricula);

        queryList = queryList.Take(filtro.Limit ?? 100);

        var viewModelList = Mapper.Map<IEnumerable<Models.Entities.Matricula>, IEnumerable<MatriculaViewModel>>(queryList.ToList());

        if (filtro.PeriodoDataProvaRecebida.Inicio.HasValue || filtro.PeriodoDataProvaRecebida.Final.HasValue)
        {
            var dtInicioProvaRecebida = filtro.PeriodoDataProvaRecebida.Inicio ?? DateTime.MinValue;
            var dtFinalProvaRecebida = filtro.PeriodoDataProvaRecebida.Final ?? DateTime.MaxValue;
            viewModelList = viewModelList.Where(x => x.UltimaProvaRealizada != null
                        && x.UltimaProvaRealizada.DataRecebidaProva >= dtInicioProvaRecebida
                        && x.UltimaProvaRealizada.DataRecebidaProva <= dtFinalProvaRecebida);
        }

        return viewModelList;
    }
}
