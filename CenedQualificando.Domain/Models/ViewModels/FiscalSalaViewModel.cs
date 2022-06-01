using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public class FiscalSalaViewModel : ViewModel<FiscalSala>
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
        public string UfDescricao => Uf.EnumDescription();
    }
}