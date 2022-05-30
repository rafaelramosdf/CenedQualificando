using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.ValueObjects;

namespace CenedQualificando.Domain.Interfaces.Requirements
{
    public interface IRequirement<TDto>
        where TDto : IDto
    {
        public CommandResult Execute(TDto model);
    }
}
