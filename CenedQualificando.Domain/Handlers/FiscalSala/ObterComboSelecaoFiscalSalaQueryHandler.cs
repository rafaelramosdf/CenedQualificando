using AutoMapper;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.FiscalSala;

public interface IObterComboSelecaoFiscalSalaQueryHandler : ISelectQueryHandler
{
}

public class ObterComboSelecaoFiscalSalaQueryHandler : IObterComboSelecaoFiscalSalaQueryHandler
{
    private readonly ILogger<ObterComboSelecaoFiscalSalaQueryHandler> Logger;
    private readonly IFiscalSalaRepository Repository;
    private readonly IMapper Mapper;

    public ObterComboSelecaoFiscalSalaQueryHandler(
        IFiscalSalaRepository repository,
        IMapper mapper,
        ILogger<ObterComboSelecaoFiscalSalaQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public IEnumerable<SelectResult> Execute(string search, int limit, int selected = 0)
    {
        Logger.LogInformation($"Iniciando handler ObterComboSelecaoFiscalSalaQueryHandler");

        var selectList = new List<SelectResult>();

        var query = !string.IsNullOrEmpty(search)
            ? Repository.List(x => x.Nome.Contains(search) || x.Cpf == search)
            : Repository.List();

        query
            .Where(x => true)
            .OrderBy(o => o.Nome)
            .Take(limit)
            .Select(s => new
            {
                s.IdFiscalSala,
                s.Nome,
                s.Cpf
            });

        var list = query.ToList();

        if (list.Any())
        {
            foreach (var item in list)
            {
                selectList.Add(new SelectResult
                {
                    Id = item.IdFiscalSala,
                    Text = $"{item.Nome.ToUpper()} | CPF: {item.Cpf}"
                });
            }
        }

        if (selected > 0 && !selectList.Any(a => a.Id == selected))
        {
            var entity = Repository.Get(selected);
            selectList.Add(new SelectResult
            {
                Id = entity.Id,
                Text = $"{entity.Nome.ToUpper()} | CPF: {entity.Cpf}"
            });

            selectList = selectList.OrderBy(o => o.Text).ToList();
        }

        return selectList;
    }
}
