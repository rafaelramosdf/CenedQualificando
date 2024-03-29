﻿using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class ProvaViewModel : ViewModel<Prova>
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
    }
}
