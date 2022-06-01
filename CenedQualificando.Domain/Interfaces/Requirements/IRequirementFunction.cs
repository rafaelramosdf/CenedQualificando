using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Interfaces.Requirements
{
    public interface IRequirementFunction<TViewModel>
        where TViewModel : IViewModel
    {
        public void Run(TViewModel vm);
    }
}
