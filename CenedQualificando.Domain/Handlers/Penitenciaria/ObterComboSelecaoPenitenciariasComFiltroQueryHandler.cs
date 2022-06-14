using AutoMapper;
using CenedQualificando.Domain.Models.Filters;
using CenedQualificando.Domain.Queries.Contracts;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Linq;
using CenedQualificando.Domain.Models.Base;
using System.Collections.Generic;
using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Domain.Extensions;

namespace CenedQualificando.Domain.Handlers.Penitenciaria;

public interface IObterComboSelecaoPenitenciariasComFiltroQueryHandler : ISelectQueryHandler<PenitenciariaFilter> 
{
}

public class ObterComboSelecaoPenitenciariasComFiltroQueryHandler : IObterComboSelecaoPenitenciariasComFiltroQueryHandler
{
    private readonly ILogger<ObterComboSelecaoPenitenciariasComFiltroQueryHandler> Logger;
    private readonly IPenitenciariaQuery Query;
    private readonly IPenitenciariaRepository Repository;
    private readonly IMapper Mapper;

    public ObterComboSelecaoPenitenciariasComFiltroQueryHandler(
        IPenitenciariaQuery query,
        IPenitenciariaRepository repository,
        IMapper mapper,
        ILogger<ObterComboSelecaoPenitenciariasComFiltroQueryHandler> logger)
    {
        Logger = logger;
        Query = query;
        Repository = repository;
        Mapper = mapper;
    }

    public IEnumerable<SelectResult> Execute(PenitenciariaFilter filtro)
    {
        Logger.LogInformation($"Iniciando handler ObterComboSelecaoPenitenciariasComFiltroQueryHandler");

        var queryList = Repository.List(Query.ObterPesquisa(filtro));

        queryList = Query.FiltrarPenitenciarias(filtro, queryList);

        queryList = queryList.OrderBy(o => o.Nome);

        queryList = queryList.Take(filtro.Limit ?? 100);

        var selectList = queryList.Select(p => new 
        {
            p.IdPenitenciaria,
            p.Nome,
            p.Uf
        }).ToList();

        var result = new List<SelectResult>();

        if (selectList.Any()) 
        {
            foreach (var item in selectList)
            {
                result.Add(new SelectResult
                {
                    Id = item.IdPenitenciaria,
                    Text = $"{item.Nome} | {((UfEnum)item.Uf).EnumDescription()}"
                });
            }
        }

        return result;
    }
}
