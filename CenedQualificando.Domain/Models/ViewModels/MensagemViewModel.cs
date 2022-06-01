using CenedQualificando.Domain.Models.Base;
using CenedQualificando.Domain.Models.Entities;
using System;

namespace CenedQualificando.Domain.Models.ViewModels
{
    public partial class MensagemViewModel : ViewModel<Mensagem>
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
    }
}
