using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class Prova : Entity
    {
        public override int Id => IdProva;

        public int IdProva { get; set; }
        public string TipoProva { get; set; }
        public DateTime? DataEnvioProva { get; set; }
        public DateTime? DataAgendadaProva { get; set; }
        public DateTime? DataRecebidaProva { get; set; }
        public decimal? Nota { get; set; }
        public int ResultadoProva { get; set; }
        public int IdMatricula { get; set; }

        public virtual Matricula IdMatriculaNavigation { get; set; }
    }
}
