using CenedQualificando.Domain.Extensions;
using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using CenedQualificando.Domain.Models.Enumerations;
using System.Collections.Generic;
using System.Linq;

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
        public AtivoEnum Ativo { get; set; }
        public string AtivoDescricao => Ativo.EnumDescription();

        public ICollection<ImpressaoCertificadoDto> ImpressaoCertificado { get; set; }

        public override void Validate()
        {
        }
    }
}
