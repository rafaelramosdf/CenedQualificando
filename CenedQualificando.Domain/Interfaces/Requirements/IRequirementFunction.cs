using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Interfaces.Requirements
{
    public interface IRequirementFunction<TDto>
        where TDto : IDto
    {
        public void Run(TDto model);
    }
}
