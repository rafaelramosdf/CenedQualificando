using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Queries.Filters.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Handlers;

public interface IByIdQueryHandler<TViewModel>
    where TViewModel : IViewModel
{
    TViewModel Execute(int id);
}
public interface IByIdQueryHandlerAsync<TViewModel>
    where TViewModel : IViewModel
{
    Task<TViewModel> Execute(int id);
}

public interface IDataTableQueryHandler<TViewModel, TFilter>
    where TViewModel : IViewModel
    where TFilter : Filter
{
    DataTableModel<TViewModel> Execute(TFilter filtro);
}
public interface IDataTableQueryHandlerAsync<TViewModel, TFilter>
    where TViewModel : IViewModel
    where TFilter : Filter
{
    Task<DataTableModel<TViewModel>> Execute(TFilter filtro);
}

public interface IEnumerableQueryHandler<TViewModel, TFilter>
    where TViewModel : IViewModel
    where TFilter : Filter
{
    IEnumerable<TViewModel> Execute(TFilter filtro);
}
public interface IEnumerableQueryHandlerAsync<TViewModel, TFilter>
    where TViewModel : IViewModel
    where TFilter : Filter
{
    Task<IEnumerable<TViewModel>> Execute(TFilter filtro);
}

public interface ISelectQueryHandler 
{
    IEnumerable<SelectResult> Execute(string search, int limit, int selected);
}
public interface ISelectQueryHandlerAsync
{
    Task<IEnumerable<SelectResult>> Execute(string search, int limit, int selected);
}