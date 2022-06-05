using AutoMapper;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using CenedQualificando.Domain.Models.Base;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Handlers.Matricula;

public interface IObterDataTableMatriculasQueryHandler : IDataTableQueryHandlerAsync<MatriculaViewModel, MatriculaFilter>
{
}

public class ObterDataTableMatriculasQueryHandler : IObterDataTableMatriculasQueryHandler
{
    private readonly ILogger<ObterDataTableMatriculasQueryHandler> Logger;
    private readonly IMatriculaQuery Query;
    private readonly IMatriculaRepository Repository;
    private readonly IMapper Mapper;

    public ObterDataTableMatriculasQueryHandler(
        IMatriculaQuery query,
        IMatriculaRepository repository,
        IMapper mapper,
        ILogger<ObterDataTableMatriculasQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public async Task<DataTableModel<MatriculaViewModel>> Execute(MatriculaFilter filtro)
    {
        return await Task.Run(() => 
        {
            Logger.LogInformation($"Iniciando handler ObterDataTableMatriculasQueryHandler");

            var dataTableModel = new DataTableModel<MatriculaViewModel>();

            IQueryable<Models.Entities.Matricula> queryList = Repository
                .List(Query.ObterPesquisa(filtro))
                .Include(i => i.Penitenciaria)
                .Include(i => i.Aluno)
                .Include(i => i.Curso);

            queryList = Query.FiltrarMatriculas(filtro, queryList);

            dataTableModel.SortAndPage(queryList, filtro, Query, Mapper);

            return dataTableModel;
        });
    }
}
