using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Interfaces.Requirements
{
    public interface IRequirement<TViewModel>
        where TViewModel : IViewModel
    {
        public CommandResult Execute(TViewModel vm);
    }
}
