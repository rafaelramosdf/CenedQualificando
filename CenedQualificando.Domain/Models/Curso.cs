using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class Curso : Entity
    {
        public Curso()
        {
            CursoUfCurso = new HashSet<CursoUfCurso>();
            EstoqueMaterial = new HashSet<EstoqueMaterial>();
            GruposProvaUfCurso = new HashSet<GruposProvaUfCurso>();
            ImpressaoCertificado = new HashSet<ImpressaoCertificado>();
            Matricula = new HashSet<Matricula>();
        }

        public override int Id => IdCurso;

        public int IdCurso { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int CargaHoraria { get; set; }
        public decimal Taxa { get; set; }
        public decimal ValorTotal { get; set; }
        public string Conteudo { get; set; }
        public int Ativo { get; set; }

        public virtual ICollection<CursoUfCurso> CursoUfCurso { get; set; }
        public virtual ICollection<EstoqueMaterial> EstoqueMaterial { get; set; }
        public virtual ICollection<GruposProvaUfCurso> GruposProvaUfCurso { get; set; }
        public virtual ICollection<ImpressaoCertificado> ImpressaoCertificado { get; set; }
        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}
