using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class DeclaracaoCursosConcluidos : Entity
    {
        public override int Id => IdDeclaracaoCursosConcluidos;

        public int IdDeclaracaoCursosConcluidos { get; set; }
        public string Prefixo { get; set; }
        public int Numero { get; set; }
        public string NumeroCriptografado { get; set; }
        public int IdAluno { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public DateTime? DataGeracao { get; set; }
    }
}
