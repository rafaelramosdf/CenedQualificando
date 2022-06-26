namespace CenedQualificando.Domain.Models.Dtos
{
    public class DadosAutenticacaoUsuarioDto
    {
        public string IdUsuario { get; set; }
        public string IdGrupoPermissao { get; set; }
        public string Usuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Autenticado { get; set; }
        public string Permissoes { get; set; }
    }
}
