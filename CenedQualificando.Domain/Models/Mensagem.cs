using CenedQualificando.Domain.Models.Base;
using System;
using System.Collections.Generic;

namespace CenedQualificando.Domain.Models
{
    public partial class Mensagem : Entity
    {

        public override int Id => IdMensagem;

        public int IdMensagem { get; set; }
        public int IdAluno { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public DateTime DataEnvio { get; set; }
        public int Autor { get; set; }
        public string UsuarioEmitente { get; set; }
        public int CopiaPara { get; set; }

        public virtual Aluno IdAlunoNavigation { get; set; }
    }
}
