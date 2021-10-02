using CenedQualificando.Domain.Interfaces.Requirements;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Utils;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Requirements
{
    public abstract class BaseRequirement<TDto> : IRequirement<TDto>
        where TDto : IDto
    {
        public IList<IRequirementException<TDto>> Exceptions { get; set; }
        public IList<IRequirementFunction<TDto>> Functions { get; set; }

        public BaseRequirement(IList<IRequirementException<TDto>> exceptions, IList<IRequirementFunction<TDto>> functions)
        {
            Exceptions = exceptions;
            Functions = functions;
        }

        public virtual CommandResult Execute(TDto model)
        {
            var commandResult = new CommandResult();

            ValidExceptions(commandResult, model);

            if (commandResult.HasError)
                return commandResult;

            RunFunctions(commandResult, model);

            return commandResult;
        }

        protected void ValidExceptions(CommandResult commandResult, TDto model)
        {
            foreach (var e in Exceptions)
            {
                if (!e.IsValid(model))
                    commandResult.SetError(e.Message);
            }
        }

        protected void RunFunctions(CommandResult commandResult, TDto model)
        {
            if (!commandResult.HasError)
            {
                foreach (var f in Functions)
                {
                    f.Run(model);
                }
            }
        }
    }
}
