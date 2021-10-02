using CenedQualificando.Domain.Interfaces.Repository;
using CenedQualificando.Domain.Interfaces.Requirements.Aluno.Exceptions;
using CenedQualificando.Domain.Models.Dtos;
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

        public bool IsValid(AlunoDto model) 
        {
            return !_alunoRepository.List(a => a.Cpf == model.Cpf).Any();
        }
    }
}
