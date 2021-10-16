using Dindin.Helper;
using System;

namespace Dindin.Model
{
    public class Curso
    {
        private int ID { get; set; }
        private string Titulo { get; set; }
        private string Capa { get; set; }
        private string NomeProfessor { get; set; }
        private string Descricao { get; set; }

        public Curso(int id, string titulo, string capa, string nomeProfessor, string descricao)
        {
            this.ID = id;
            this.Titulo = titulo.ValidarStringVazia();
            this.Capa = capa.ValidarStringVazia();
            this.NomeProfessor = nomeProfessor.ValidarStringVazia();
            this.Descricao = descricao.ValidarStringVazia();
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
        public string retornaCapa()
        {
            return this.Capa;
        }
        public string retornaNomeProfessor()
        {
            return this.NomeProfessor;
        }
        public string retornaDescricao()
        {
            return this.Descricao;
        }
    }
}
