using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Interfaces.Requirements
{
    public interface IRequirementException<TDto>
        where TDto : IDto
    {
        public bool IsValid(TDto model);
        public string Message { get; }
    }
}
