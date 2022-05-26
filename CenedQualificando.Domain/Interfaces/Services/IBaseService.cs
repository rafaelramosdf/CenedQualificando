using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity, TDto, TFilter>
        where TEntity : Entity
        where TDto : IDto
        where TFilter : Filter
    {
        TDto Buscar(int id);
        DataTableModel<TDto> Buscar(TFilter filtro);
        IQueryable<TEntity> CriarConsulta();
        IQueryable<TEntity> FiltrarConsulta(IQueryable<TEntity> queryList, Expression<Func<TEntity, bool>> filterExpression = null);
        IQueryable<TEntity> OrdenarConsulta(IQueryable<TEntity> queryList, DataTableSortingModel sortingModel);
        IQueryable<TEntity> PaginarConsulta(IQueryable<TEntity> queryList, DataTablePaginationModel paginationModel);

        CommandResult Incluir(TDto vm);
        CommandResult Incluir(IEnumerable<TDto> vmList);

        CommandResult Alterar(TDto vm);
        CommandResult Alterar(IEnumerable<TDto> vmList);

        CommandResult Excluir(int id);
        CommandResult Excluir(IEnumerable<int> idList);
    }
}
