using AutoMapper;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.AgentePenitenciario;

public interface IObterComboSelecaoAgentesPenitenciariosQueryHandler : ISelectQueryHandler
{
}

public class ObterComboSelecaoAgentesPenitenciariosQueryHandler : IObterComboSelecaoAgentesPenitenciariosQueryHandler
{
    private readonly ILogger<ObterComboSelecaoAgentesPenitenciariosQueryHandler> Logger;
    private readonly IAgentePenitenciarioRepository Repository;
    private readonly IMapper Mapper;

    public ObterComboSelecaoAgentesPenitenciariosQueryHandler(
        IAgentePenitenciarioRepository repository,
        IMapper mapper,
        ILogger<ObterComboSelecaoAgentesPenitenciariosQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public IEnumerable<SelectResult> Execute(string search, int limit = 10, int selected = 0)
    {
        Logger.LogInformation($"Iniciando handler ObterComboSelecaoAgentesPenitenciariosQueryHandler");

        var selectList = new List<SelectResult>();

        var query = !string.IsNullOrEmpty(search)
            ? Repository.List(x => x.Nome.Contains(search) || x.CpfUsuario == search)
            : Repository.List();

        query
            .Where(x => x.IdPenitenciaria > 1)
            .OrderBy(o => o.Nome)
            .Take(limit)
            .Select(s => new
            {
                s.IdAgentePenitenciario,
                s.Nome,
                s.CpfUsuario
            });

        var list = query.ToList();

        if (list.Any())
        {
            foreach (var item in list)
            {
                selectList.Add(new SelectResult
                {
                    Id = item.IdAgentePenitenciario,
                    Text = $"{item.Nome.ToUpper()} | CPF: {item.CpfUsuario}"
                });
            }
        }

        if (selected > 0 && !selectList.Any(a => a.Id == selected))
        {
            var entity = Repository.Get(selected);
            selectList.Add(new SelectResult
            {
                Id = entity.Id,
                Text = $"{entity.Nome.ToUpper()} | CPF: {entity.CpfUsuario}"
            });

            selectList = selectList.OrderBy(o => o.Text).ToList();
        }

        return selectList;
    }
}
