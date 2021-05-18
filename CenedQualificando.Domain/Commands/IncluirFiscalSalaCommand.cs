using CenedQualificando.Domain.Interfaces.Commands;
using CenedQualificando.Domain.Models;
using Flunt.Validations;
using Flunt.Extensions.Br.Validations;

namespace CenedQualificando.Domain.Commands
{
    public class IncluirFiscalSalaCommand : Contract<FiscalSala>, ICommand
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public int Uf { get; set; }

        public void Validate()
        {
            Requires()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Preencha o campo 'Nome'")
                .IsCpf(Cpf, nameof(Cpf), "CPF inválido");
        }
    }
}
