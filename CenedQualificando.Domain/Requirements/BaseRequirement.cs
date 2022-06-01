using CenedQualificando.Domain.Interfaces.Requirements;
using CenedQualificando.Domain.Models.Base;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Requirements
{
    public abstract class BaseRequirement<TViewModel> : IRequirement<TViewModel>
        where TViewModel : IViewModel
    {
        public IList<IRequirementException<TViewModel>> Exceptions { get; set; }
        public IList<IRequirementFunction<TViewModel>> Functions { get; set; }

        public BaseRequirement(IList<IRequirementException<TViewModel>> exceptions, IList<IRequirementFunction<TViewModel>> functions)
        {
            Exceptions = exceptions;
            Functions = functions;
        }

        public virtual CommandResult Execute(TViewModel model)
        {
            var commandResult = new CommandResult();

            ValidExceptions(commandResult, model);

            if (commandResult.HasError)
                return commandResult;

            RunFunctions(commandResult, model);

            return commandResult;
        }

        protected void ValidExceptions(CommandResult commandResult, TViewModel model)
        {
            foreach (var e in Exceptions)
            {
                if (!e.IsValid(model))
                    commandResult.SetError(e.Message);
            }
        }

        protected void RunFunctions(CommandResult commandResult, TViewModel model)
        {
            if (!commandResult.HasError)
            {
                foreach (var f in Functions)
                {
                    try
                    {
                        f.Run(model);
                    }
                    catch (System.Exception ex)
                    {
                        commandResult.SetError($"Erro ao executar a função \"{f.GetType().Name}\" | Message: {ex.Message}");
                    }
                }
            }
        }
    }
}
