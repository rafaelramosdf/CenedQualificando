using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Queries.Filters.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity, TViewModel, TFilter>
        where TEntity : Entity
        where TViewModel : IViewModel
        where TFilter : Filter
    {
        TViewModel Buscar(int id);
        DataTableModel<TViewModel> Buscar(TFilter filtro);
        IQueryable<TEntity> CriarConsulta();
        IQueryable<TEntity> FiltrarConsulta(IQueryable<TEntity> queryList, Expression<Func<TEntity, bool>> filterExpression = null);
        IQueryable<TEntity> OrdenarConsulta(IQueryable<TEntity> queryList, DataTableSortingModel sortingModel);
        IQueryable<TEntity> PaginarConsulta(IQueryable<TEntity> queryList, DataTablePaginationModel paginationModel);

        CommandResult Incluir(TViewModel vm);
        CommandResult Incluir(IEnumerable<TViewModel> vmList);

        CommandResult Alterar(TViewModel vm);
        CommandResult Alterar(IEnumerable<TViewModel> vmList);

        CommandResult Excluir(int id);
        CommandResult Excluir(IEnumerable<int> idList);
    }
}
