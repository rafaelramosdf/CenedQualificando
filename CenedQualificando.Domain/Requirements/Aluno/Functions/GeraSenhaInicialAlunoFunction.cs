using CenedQualificando.Domain.Interfaces.Requirements.Aluno.Functions;
using CenedQualificando.Domain.Models.Dtos;

namespace CenedQualificando.Domain.Requirements.Aluno.Functions
{
    public class GeraSenhaInicialAlunoFunction : IGeraSenhaInicialAlunoFunction
    {
        public void Run(AlunoDto model)
        {
            model.Penitenciaria = null; // TODO: Remover pra outra function

            // TODO: Verificar padrao para senha inicial
            model.Senha = "123";
            model.ConfirmarSenha = "123";
        }
    }
}
