using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.Dtos
{
    public partial class CursoDto : Dto<Curso>
    {
        public override int Id => IdCurso;

        public int IdCurso { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int CargaHoraria { get; set; }
        public decimal Taxa { get; set; }
        public decimal ValorTotal { get; set; }
        public string Conteudo { get; set; }
        public int Ativo { get; set; }

        public override void Validate()
        {
        }
    }
}
