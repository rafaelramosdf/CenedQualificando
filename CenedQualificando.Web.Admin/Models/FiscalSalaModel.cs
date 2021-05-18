using CenedQualificando.Domain.Models.Enumerations;
using CenedQualificando.Web.Admin.Models.Base;

namespace CenedQualificando.Web.Admin.Models
{
    public class FiscalSalaModel : BaseModel
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
    }
}
