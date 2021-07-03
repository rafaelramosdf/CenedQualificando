using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Utils;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CenedQualificando.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity, TDto>
        where TEntity : Entity
        where TDto : IDto
    {
        TDto Buscar(int id);
        DataTableModel<TDto> Buscar(DataTableModel<TDto> dataTableModel);
        IQueryable<TEntity> CriarConsulta();
        IQueryable<TEntity> FiltrarConsulta(IQueryable<TEntity> queryList, Expression<Func<TEntity, bool>> filterExpression = null);
        IQueryable<TEntity> OrdenarConsulta(IQueryable<TEntity> queryList, DataTableSortingModel<TDto> sortingModel);
        IQueryable<TEntity> PaginarConsulta(IQueryable<TEntity> queryList, DataTablePaginationModel paginationModel);

        TDto Incluir(TDto vm);
        void Alterar(TDto vm);
        void Excluir(TDto vm);
    }
}
