﻿using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class GrupoProvaViewModel : ViewModel<GrupoProva>
    {
        public override int Id => IdGrupoProva;

        public int IdGrupoProva { get; set; }
        public string Nome { get; set; }
        public int Ativo { get; set; }
        public string Prova1 { get; set; }
        public string Prova2 { get; set; }
        public string Prova3 { get; set; }
        public string Prova4 { get; set; }
        public string Prova5 { get; set; }
    }
}
