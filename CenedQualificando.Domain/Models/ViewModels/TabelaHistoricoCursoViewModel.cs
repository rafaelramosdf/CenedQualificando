using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class TabelaHistoricoCursoViewModel : ViewModel<TabelaHistoricoCurso>
    {
        public override int Id => IdTabelaHistoricoCurso;

        public int IdTabelaHistoricoCurso { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Agrupador { get; set; }
        public int Tipo { get; set; }
        public bool PreDefinido { get; set; }
        public int Ativo { get; set; }
    }
}
