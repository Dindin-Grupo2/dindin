using Dindin.DAO;
using Dindin.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dindin.Classes
{
    public class CursoRepositorio
    {
        private Curso curso;

        public bool Inserir(Curso curso, List<Aula> listaAula)
        {
            try
            {
                int? idFK = ConexaoBanco.executaComando($"INSERT INTO curso (titulo, capa, nome_professor, descricao) VALUES ('{curso.retornaTitulo()}', '{curso.retornaCapa()}', '{curso.retornaNomeProfessor()}', '{curso.retornaDescricao()}')", true);

                foreach (var aula in listaAula)
                {
                    ConexaoBanco.executaComando($"INSERT INTO aula (titulo, link, descricao, id_curso) VALUES ('{aula.retornaTitulo()}', '{aula.retornaLink()}','{aula.retornaDescricao()}', {idFK})", false);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Atualizar(int id, Curso curso, List<Aula> listaAula)
        {
            try
            {
                DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");
                int idFKAula = 0;

                if (dt.Rows.Count > 0)
                {
                    idFKAula = Convert.ToInt32($"{dt.Rows[0]["idcurso"]}");

                    ConexaoBanco.executaComando(@$"UPDATE curso 
                                           SET titulo = '{curso.retornaTitulo()}',
                                           capa = '{curso.retornaCapa()}',
                                           nome_professor = '{curso.retornaNomeProfessor()}',
                                           descricao = '{curso.retornaDescricao()}'
                                           WHERE idcurso = {id}", false);

                    foreach (var aula in listaAula)
                    {
                        ConexaoBanco.executaComando(@$"UPDATE aula 
                                           SET titulo = '{aula.retornaTitulo()}',
                                           link = '{aula.retornaLink()}',
                                           descricao = '{aula.retornaDescricao()}'
                                           WHERE id_curso = {idFKAula}" , false);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");
                int idFKAula = 0;

                if (dt.Rows.Count > 0)
                {
                    idFKAula = Convert.ToInt32($"{dt.Rows[0]["idcurso"]}");
                    ConexaoBanco.executaComando($"DELETE FROM aula WHERE aula.id_curso = {idFKAula}", false);
                    ConexaoBanco.executaComando($"DELETE FROM curso WHERE curso.idcurso = {id}", false);                   
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Curso> ListarCursos()
        {
            List<Curso> listaCurso = new List<Curso>();

            DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int idCurso = Convert.ToInt32($"{dt.Rows[0]["idcurso"]}");
                    string titulo = $"{dt.Rows[i]["titulo"]}";
                    string capa = $"{dt.Rows[i]["capa"]}";
                    string nomeProfessor = $"{dt.Rows[i]["nome_professor"]}";
                    string descricao = $"{dt.Rows[i]["descricao"]}";
                    curso = new Curso(idCurso, titulo, capa, nomeProfessor, descricao);

                    listaCurso.Add(curso);
                }
            }
            else
            {
                return null;
            }
            return listaCurso;
        }

        public Curso RetornaPorIDCurso(int id)
        {
            DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");

            if (dt.Rows.Count > 0)
            {
                int idCurso = Convert.ToInt32($"{dt.Rows[0]["idcurso"]}");
                string tituloCurso = $"{dt.Rows[0]["titulo"]}";
                string capa = $"{dt.Rows[0]["capa"]}";
                string nomeProfessor = $"{dt.Rows[0]["nome_professor"]}";
                string descricaoCurso = $"{dt.Rows[0]["descricao"]}";
                this.curso = new Curso(idCurso, tituloCurso, capa, nomeProfessor, descricaoCurso);
            }
            else
            {
                return null;
            }
            return this.curso;
        }

        public List<Aula> RetornaPorIDAula(int id)
        {
            List<Aula> listaAula = new List<Aula>();
            DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");

            if (dt.Rows.Count > 0)
            {
                int idFKAula = Convert.ToInt32($"{dt.Rows[0]["idcurso"]}");
                DataTable dtAula = ConexaoBanco.retornaDados($"SELECT * FROM aula WHERE aula.id_curso = {idFKAula}");

                if (dtAula.Rows.Count > 0)
                {
                    for (int i = 0; i < dtAula.Rows.Count; i++)
                    {
                        string tituloAula = $"{dtAula.Rows[i]["titulo"]}";
                        string link = $"{dtAula.Rows[i]["link"]}";
                        string descricaoAula = $"{dtAula.Rows[i]["descricao"]}";
                        listaAula.Add(new Aula(tituloAula, link, descricaoAula));
                    }
                }
            }
            else
            {
                return null;
            }
            return listaAula;
        }

    }

}

