using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class CargaHorariaDiaria : Entity
    {
        public override int Id => IdCargaHorariaDiaria;

        public int IdCargaHorariaDiaria { get; set; }
        public int CargaHoraria { get; set; }
        public int Uf { get; set; }
    }
}
