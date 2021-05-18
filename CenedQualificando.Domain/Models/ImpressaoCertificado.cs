using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class ImpressaoCertificado : Entity
    {
        public override int Id => IdImpressaoCertificado;

        public int IdImpressaoCertificado { get; set; }
        public int IdCurso { get; set; }
        public string Frente { get; set; }
        public string ConteudoCurso { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
    }
}
