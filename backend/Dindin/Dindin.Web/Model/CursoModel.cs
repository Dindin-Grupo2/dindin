using Dindin.Model;
using System.ComponentModel.DataAnnotations;

namespace Dindin.Web.Model
{
    public class CursoModel
    {
        public int ID { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Capa { get; set; }
        [Required]
        public string NomeProfessor { get; set; }
        [Required]
        public string Descricao { get; set; }

        public CursoModel()
        {
                
        }

        public CursoModel(Curso curso)
        {
            this.ID = curso.retornaID();
            this.Titulo = curso.retornaTitulo();
            this.Capa = curso.retornaCapa();
            this.NomeProfessor = curso.retornaNomeProfessor();
            this.Descricao = curso.retornaDescricao();
        }

        public Curso ToCurso()
        {
            return new Curso(ID, Titulo, Capa, NomeProfessor, Descricao);
        }
    }
}
