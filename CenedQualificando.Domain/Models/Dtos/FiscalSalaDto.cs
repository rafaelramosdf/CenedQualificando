using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;
using Flunt.Extensions.Br.Validations;

namespace CenedQualificando.Domain.Models.Dtos
{
    public class FiscalSalaDto : Dto<FiscalSala>
    {
        public override int Id
        {
            get => IdFiscalSala;
            set => IdFiscalSala = value;
        }

        public int IdFiscalSala { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public UfEnum Uf { get; set; }
        public string UfDescricao => Uf.GetDescription();

        public override void Validate()
        {
            Requires()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Preencha o campo 'Nome'")
                .IsCpf(Cpf, nameof(Cpf), "CPF inválido");
        }
    }
}