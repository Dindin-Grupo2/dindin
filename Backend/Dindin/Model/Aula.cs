using Dindin.Helper;

namespace Dindin.Model
{
    public class Aula
    {
        private string Titulo { get; set; }
        private string Link { get; set; }
        private string Descricao { get; set; }

        public Aula(string titulo, string link, string descricao)
        {
            this.Titulo = titulo.ValidarStringVazia();
            this.Link = link.ValidarStringVazia();
            this.Descricao = descricao.ValidarStringVazia();
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public string retornaLink()
        {
            return this.Link;
        }
        public string retornaDescricao()
        {
            return this.Descricao;
        }
    }
}
