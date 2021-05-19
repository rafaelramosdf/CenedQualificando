using CenedQualificando.Domain.Models.Base;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class FiscalSala : Entity
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
        public int Uf { get; set; }
    }
}
