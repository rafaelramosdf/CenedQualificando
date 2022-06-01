using CenedQualificando.Domain.Interfaces.Requirements.Aluno.Exceptions;
using CenedQualificando.Domain.Models.ViewModels;
using CenedQualificando.Domain.Repositories.Contracts;
using System.Linq;

namespace CenedQualificando.Domain.Requirements.Aluno.Exceptions
{
    public class CpfDuplicadoAlunoException : ICpfDuplicadoAlunoException
    {
        private readonly IAlunoRepository _alunoRepository;

        public CpfDuplicadoAlunoException(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public string Message => "O CPF informado já possui cadastro"; // TODO: Colocar no Resource

        public bool IsValid(AlunoViewModel model) 
        {
            return !_alunoRepository.List(a => a.Cpf == model.Cpf).Any();
        }
    }
}
