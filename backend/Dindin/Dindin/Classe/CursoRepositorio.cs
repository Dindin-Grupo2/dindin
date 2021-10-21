using Dindin.DAO;
using Dindin.Inteface;
using Dindin.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dindin.Classes
{
    public class CursoRepositorio : IRepositorio
    {
        private Curso curso;        

        public List<Curso> GetCursos()
        {
            List<Curso> listaCurso = new List<Curso>();

            DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int idCurso = Convert.ToInt32($"{dt.Rows[i]["idcurso"]}");
                    string titulo = $"{dt.Rows[i]["titulo"]}";
                    string capa = $"{dt.Rows[i]["capa"]}";
                    string nomeProfessor = $"{dt.Rows[i]["nome_professor"]}";
                    string descricao = $"{dt.Rows[i]["descricao"]}";
                    this.curso = new Curso(idCurso, titulo, capa, nomeProfessor, descricao);

                    listaCurso.Add(this.curso);
                }
            }
            else return null;

            return listaCurso;
        }

        public Curso GetCursoID(int id)
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
            else return null;
            return this.curso;
        }

        public List<Aula> GetAulasByCursoID(int id)
        {
            List<Aula> listaAula = new List<Aula>();
            DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");

            if (dt.Rows.Count > 0)
            {
                DataTable dtAula = ConexaoBanco.retornaDados($"SELECT * FROM aula WHERE aula.id_curso = {id}");

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
                else return null;
            }
            else return null;
            return listaAula;
        }

        public bool CreateCurso(Curso curso)
        {
            try
            {
                ConexaoBanco.executaComando($"INSERT INTO curso (titulo, capa, nome_professor, descricao) VALUES ('{curso.retornaTitulo()}', '{curso.retornaCapa()}', '{curso.retornaNomeProfessor()}', '{curso.retornaDescricao()}')", true);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateAulaByCursoTitulo(string titulo, List<Aula> listaAula)
        {
            try
            {
                DataTable dt = ConexaoBanco.retornaDados($"(SELECT * FROM curso WHERE curso.titulo = '{titulo}')");

                if (dt.Rows.Count > 0)
                {
                    string idFK = $"{dt.Rows[0]["idcurso"]}";

                    for (int i = 0; i < listaAula.Count; i++)
                    {
                        Aula aula = new Aula(listaAula[i].retornaTitulo(), listaAula[i].retornaLink(), listaAula[i].retornaDescricao());
                        ConexaoBanco.executaComando($"INSERT INTO aula (titulo, link, descricao, id_curso) VALUES ('{aula.retornaTitulo()}', '{aula.retornaLink()}','{aula.retornaDescricao()}', {Convert.ToInt32(idFK)})", false);
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateCurso(int id, Curso curso)
        {
            try
            {
                DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");

                if (dt.Rows.Count > 0)
                {
                    ConexaoBanco.executaComando(@$"UPDATE curso 
                                           SET titulo = '{curso.retornaTitulo()}',
                                           capa = '{curso.retornaCapa()}',
                                           nome_professor = '{curso.retornaNomeProfessor()}',
                                           descricao = '{curso.retornaDescricao()}'
                                           WHERE idcurso = {id}", false);
                }
                else return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateAulasByCursoTitulo(int id, string tituloAula, List<Aula> listaAula)
        {
            try
            {
                DataTable dt = ConexaoBanco.retornaDados($"(SELECT * FROM curso WHERE curso.idcurso = {id})");

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < listaAula.Count; i++)
                    {
                        DataTable dtAula = ConexaoBanco.retornaDados($"SELECT * FROM aula WHERE aula.id_curso = {id} AND aula.titulo = '{tituloAula}'");
                       
                        if (dtAula.Rows.Count > 0)
                        {
                            ConexaoBanco.executaComando(@$"UPDATE aula SET titulo = '{listaAula[i].retornaTitulo()}',
                                           link = '{listaAula[i].retornaLink()}',
                                           descricao = '{listaAula[i].retornaDescricao()}'
                                           WHERE aula.id_curso = {id} AND aula.titulo = '{tituloAula}'", false);
                        }
                    }
                }
                else return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCurso(int id)
        {
            try
            {
                DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");

                if (dt.Rows.Count > 0)
                {
                    ConexaoBanco.executaComando($"DELETE FROM aula WHERE aula.id_curso = {id}", false);
                    ConexaoBanco.executaComando($"DELETE FROM curso WHERE curso.idcurso = {id}", false);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteAulaByCursoID(int id, string tituloAula)
        {
            try
            {
                DataTable dtCurso = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.idcurso = {id}");

                if (dtCurso.Rows.Count > 0)
                {
                    DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM aula WHERE aula.id_curso = {id} AND aula.titulo = '{tituloAula}'");
                    if (dt.Rows.Count > 0)
                    {
                        ConexaoBanco.executaComando($"DELETE FROM aula WHERE aula.id_curso = {id} AND aula.titulo = '{tituloAula}'", false);
                    }
                    else return false;
                }
                else return false;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}

