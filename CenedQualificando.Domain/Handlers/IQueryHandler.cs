using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.ValueObjects;
using CenedQualificando.Domain.Queries.Filters.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Handlers;

public interface IByIdQueryHandler<TDto>
    where TDto : IDto
{
    TDto Execute(int id);
}
public interface IByIdQueryHandlerAsync<TDto>
    where TDto : IDto
{
    Task<TDto> Execute(int id);
}

public interface IDataTableQueryHandler<TDto, TFilter>
    where TDto : IDto
    where TFilter : Filter
{
    DataTableModel<TDto> Execute(TFilter filtro);
}
public interface IDataTableQueryHandlerAsync<TDto, TFilter>
    where TDto : IDto
    where TFilter : Filter
{
    Task<DataTableModel<TDto>> Execute(TFilter filtro);
}

public interface IEnumerableQueryHandler<TDto, TFilter>
    where TDto : IDto
    where TFilter : Filter
{
    IEnumerable<TDto> Execute(TFilter filtro);
}
public interface IEnumerableQueryHandlerAsync<TDto, TFilter>
    where TDto : IDto
    where TFilter : Filter
{
    Task<IEnumerable<TDto>> Execute(TFilter filtro);
}

public interface ISelectQueryHandler 
{
    IEnumerable<SelectResult> Execute(string search, int limit, int selected);
}
public interface ISelectQueryHandlerAsync
{
    Task<IEnumerable<SelectResult>> Execute(string search, int limit, int selected);
}