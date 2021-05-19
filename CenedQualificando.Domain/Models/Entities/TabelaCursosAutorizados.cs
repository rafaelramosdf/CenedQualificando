using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models.Entities
{
    public partial class TabelaCursosAutorizados : Entity
    {
        public override int Id => IdTabelaCursosAutorizados;

        public int IdTabelaCursosAutorizados { get; set; }
        public string NomePenitenciaria { get; set; }
        public string NomeAluno { get; set; }
        public string Cpf { get; set; }
        public string TelefoneCelular1 { get; set; }
        public string TelefoneCelular2 { get; set; }
        public string Curso { get; set; }
        public string Status { get; set; }
        public DateTime? DataCadastro { get; set; }
    }
}
