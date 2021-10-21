using Dindin.Model;
using System.Collections.Generic;

namespace Dindin.Inteface
{
    public interface IRepositorio
    {
        public List<Curso> GetCursos();
        public Curso GetCursoID(int id);
        public List<Aula> GetAulasByCursoID(int id);
        public bool CreateCurso(Curso curso);
        public bool CreateAulaByCursoTitulo(string tituloCurso, List<Aula> listaAula);
        public bool UpdateCurso(int id, Curso curso);
        public bool UpdateAulasByCursoTitulo(int id, string tituloAula, List<Aula> listaAula);
        public bool DeleteCurso(int id);
        public bool DeleteAulaByCursoID(int id, string tituloAula);
    }
}
