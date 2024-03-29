﻿using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class DeclaracaoCursosConcluidosViewModel : ViewModel<DeclaracaoCursosConcluidos>
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
