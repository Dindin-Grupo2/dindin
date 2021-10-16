using Dindin.Helper;
using System;

namespace Dindin.Model
{
    public class Curso
    {
        private string Titulo { get; set; }
        private string Capa { get; set; }
        private string NomeProfessor { get; set; }
        private string Descricao { get; set; }
        public Aula Aula { get; set; }

        public Curso(string titulo, string capa, string nomeProfessor, string descricao, Aula aula)
        {
            this.Titulo = titulo.ValidarStringVazia();
            this.Capa = capa.ValidarStringVazia();
            this.NomeProfessor = nomeProfessor.ValidarStringVazia();
            this.Descricao = descricao.ValidarStringVazia();
            this.Aula = aula ?? throw new Exception("O objeto aula deve ser informado");
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
