﻿using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class SolicitacaoAutorizacaoMatricula : Entity
    {
        public override int Id => IdSolicitacaoAutorizacaoMatricula;

        public int IdSolicitacaoAutorizacaoMatricula { get; set; }
        public string NomeInterno { get; set; }
        public string CpfInterno { get; set; }
        public int IdPenitenciaria { get; set; }
        public string Bloco { get; set; }
        public string Ala { get; set; }
        public string Cela { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public int GrauEscolaridade { get; set; }
        public string NomeSolicitante { get; set; }
        public string CpfSolicitante { get; set; }
        public int TipoSolicitante { get; set; }
        public string Celular { get; set; }
        public string TelefoneAdicional { get; set; }
        public string Email { get; set; }
        public string EnderecoIp { get; set; }
        public DateTime DataHora { get; set; }
        public string ListaDeCursos { get; set; }
    }
}
