using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Handlers;

public interface IDeleteCommandHandler
{
    CommandResult Execute(int id);
}

public interface IEditCommandHandler<TViewModel>
    where TViewModel : IViewModel
{
    CommandResult Execute(TViewModel vm);
}
