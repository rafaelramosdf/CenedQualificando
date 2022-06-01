using AutoMapper;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace CenedQualificando.Domain.Handlers.Aluno;

public interface IObterComboSelecaoAlunosQueryHandler : ISelectQueryHandler
{
}

public class ObterComboSelecaoAlunosQueryHandler : IObterComboSelecaoAlunosQueryHandler
{
    private readonly ILogger<ObterComboSelecaoAlunosQueryHandler> Logger;
    private readonly IAlunoRepository Repository;
    private readonly IMapper Mapper;

    public ObterComboSelecaoAlunosQueryHandler(
        IAlunoRepository repository,
        IMapper mapper,
        ILogger<ObterComboSelecaoAlunosQueryHandler> logger)
    {
        Logger = logger;
        Repository = repository;
        Mapper = mapper;
    }

    public IEnumerable<SelectResult> Execute(string search, int limit, int selected = 0)
    {
        Logger.LogInformation($"Iniciando handler ObterComboSelecaoAlunosQueryHandler");

        var selectList = new List<SelectResult>();

        var query = !string.IsNullOrEmpty(search)
            ? Repository.List(x => x.Nome.Contains(search) || x.Cpf == search)
            : Repository.List();

        query
            .Where(x => x.IdPenitenciaria > 1)
            .OrderBy(o => o.Nome)
            .Take(limit)
            .Select(s => new
            {
                s.IdAluno,
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
                    Id = item.IdAluno,
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
