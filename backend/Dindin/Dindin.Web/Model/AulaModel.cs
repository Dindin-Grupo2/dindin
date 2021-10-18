using Dindin.Model;

namespace Dindin.Web.Model
{
    public class AulaModel
    {
        public string Titulo { get; set; }
        public string Link { get; set; }
        public string Descricao { get; set; }

        public AulaModel ()
        {

        }

        public AulaModel(Aula aula)
        {
            this.Titulo = aula.retornaTitulo();
            this.Link = aula.retornaLink();
            this.Descricao = aula.retornaDescricao();
        }

        public Aula ToAula()
        {
            return new Aula(Titulo, Link, Descricao);
        }
    }
}
