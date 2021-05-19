namespace CenedQualificando.Domain.Models.Entities
{
    public partial class CursoUfCurso
    {
        public int CursoUfIdCursoUf { get; set; }
        public int CursoIdCurso { get; set; }

        public virtual Curso CursoIdCursoNavigation { get; set; }
        public virtual CursoUf CursoUfIdCursoUfNavigation { get; set; }
    }
}
