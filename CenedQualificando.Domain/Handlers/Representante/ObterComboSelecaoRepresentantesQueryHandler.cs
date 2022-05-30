using AutoMapper;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.Representante;

public interface IObterComboSelecaoRepresentantesQueryHandler : ISelectQueryHandler
{
}

public class ObterComboSelecaoRepresentantesQueryHandler : IObterComboSelecaoRepresentantesQueryHandler
{
    private readonly ILogger<ObterComboSelecaoRepresentantesQueryHandler> Logger;
    private readonly IRepresentanteRepository Repository;
    private readonly IMapper Mapper;

    public ObterComboSelecaoRepresentantesQueryHandler(
        IRepresentanteRepository repository,
        IMapper mapper,
        ILogger<ObterComboSelecaoRepresentantesQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public IEnumerable<SelectResult> Execute(string search, int limit, int selected = 0)
    {
        Logger.LogInformation($"Iniciando handler ObterComboSelecaoRepresentantesQueryHandler");

        var selectList = new List<SelectResult>();

        var query = !string.IsNullOrEmpty(search)
            ? Repository.List(x => x.Nome.Contains(search))
            : Repository.List();

        query
            .Where(x => true)
            .OrderBy(o => o.Nome)
            .Take(limit)
            .Select(s => new
            {
                s.IdRepresentante,
                s.Nome
            });

        var list = query.ToList();

        if (list.Any())
        {
            foreach (var item in list)
            {
                selectList.Add(new SelectResult
                {
                    Id = item.IdRepresentante,
                    Text = $"{item.Nome.ToUpper()}"
                });
            }
        }

        if (selected > 0 && !selectList.Any(a => a.Id == selected))
        {
            var entity = Repository.Get(selected);
            selectList.Add(new SelectResult
            {
                Id = entity.Id,
                Text = $"{entity.Nome.ToUpper()}"
            });

            selectList = selectList.OrderBy(o => o.Text).ToList();
        }

        return selectList;
    }
}
