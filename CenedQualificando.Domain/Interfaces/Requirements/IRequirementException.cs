using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Interfaces.Requirements
{
    public interface IRequirementException<TViewModel>
        where TViewModel : IViewModel
    {
        public bool IsValid(TViewModel vm);
        public string Message { get; }
    }
}
