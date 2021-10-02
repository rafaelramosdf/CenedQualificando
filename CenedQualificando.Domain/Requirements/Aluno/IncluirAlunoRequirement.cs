using CenedQualificando.Domain.Interfaces.Requirements;
using CenedQualificando.Domain.Interfaces.Requirements.Aluno;
using CenedQualificando.Domain.Interfaces.Requirements.Aluno.Exceptions;
using CenedQualificando.Domain.Interfaces.Requirements.Aluno.Functions;
using CenedQualificando.Domain.Models.Dtos;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Requirements.Aluno
{
    public class IncluirAlunoRequirement : BaseRequirement<AlunoDto>, IIncluirAlunoRequirement
    {
        public IncluirAlunoRequirement(ICpfDuplicadoAlunoException cpfDuplicadoAlunoException,
            IGeraSenhaInicialAlunoFunction geraSenhaInicialAlunoFunction)
            : base(
                  new List<IRequirementException<AlunoDto>>
                  {
                      cpfDuplicadoAlunoException
                  },
                  new List<IRequirementFunction<AlunoDto>>
                  {
                      geraSenhaInicialAlunoFunction
                  })
        {
        }
    }
}
