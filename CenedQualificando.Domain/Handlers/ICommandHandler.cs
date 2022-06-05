using CenedQualificando.Domain.Models.Base;
using System.Threading.Tasks;

namespace CenedQualificando.Domain.Handlers;

public interface IDeleteCommandHandler
{
    CommandResult Execute(int id);
}
public interface IDeleteCommandHandlerAsync
{
    Task<CommandResult> Execute(int id);
}

public interface IEditCommandHandler<TViewModel>
    where TViewModel : IViewModel
{
    CommandResult Execute(TViewModel vm);
}
public interface IEditCommandHandlerAsync<TViewModel>
    where TViewModel : IViewModel
{
    Task<CommandResult> Execute(TViewModel vm);
}