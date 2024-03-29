﻿using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class HistoricoCursoViewModel : ViewModel<HistoricoCurso>
    {
        public override int Id => IdHistoricoCurso;

        public int IdHistoricoCurso { get; set; }
        public int IdMatricula { get; set; }
        public int IdTabelaHistoricoCurso { get; set; }
        public DateTime DataHora { get; set; }
        public string Valor { get; set; }
    }
}
