using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.ValueObjects;

namespace CenedQualificando.Domain.Handlers;

public interface IDeleteCommandHandler
{
    CommandResult Execute(int id);
}

public interface IEditCommandHandler<TDto>
    where TDto : IDto
{
    CommandResult Execute(TDto dto);
}
