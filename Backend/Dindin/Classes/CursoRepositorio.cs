using Dindin.DAO;
using Dindin.Interface;
using Dindin.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dindin.Classes
{
    public class CursoRepositorio : IRepositorio<Curso>
    {
        private Curso curso;
        private Aula aula;

        public bool Inserir(Curso curso)
        {
            try
            {
                int? idFK = ConexaoBanco.executaComando($"INSERT INTO curso (titulo, capa, nome_professor, descricao) VALUES ('{curso.retornaTitulo()}', '{curso.retornaCapa()}', '{curso.retornaNomeProfessor()}', '{curso.retornaDescricao()}')", true);
                ConexaoBanco.executaComando($"INSERT INTO aula (id_curso_fk, titulo, link, descricao) values ({idFK}, '{curso.Aula.retornaTitulo()}', '{curso.Aula.retornaLink()}','{curso.Aula.retornaDescricao()}')", false);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Atualizar(string titulo, Curso curso)
        {
            try
            {
                DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.titulo = '{titulo}'");
                int idFKAula = 0;

                if (dt.Rows.Count > 0)
                {
                    idFKAula = Convert.ToInt32($"{dt.Rows[0]["id_curso"]}");

                    ConexaoBanco.executaComando(@$"UPDATE curso 
                                           SET titulo = '{curso.retornaTitulo()}',
                                           capa = '{curso.retornaCapa()}',
                                           nome_professor = '{curso.retornaNomeProfessor()}',
                                           descricao = '{curso.retornaDescricao()}'
                                           WHERE titulo = '{titulo}'", false);

                    ConexaoBanco.executaComando(@$"UPDATE aula 
                                           SET titulo = '{curso.Aula.retornaTitulo()}',
                                           link = '{curso.Aula.retornaLink()}',
                                           descricao = '{curso.Aula.retornaDescricao()}'
                                           WHERE id_curso_fk = {idFKAula}", false);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Excluir(string titulo)
        {
            try
            {
                DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.titulo = '{titulo}'");
                int idFKAula = 0;

                if (dt.Rows.Count > 0)
                {
                    idFKAula = Convert.ToInt32($"{dt.Rows[0]["id_curso"]}");
                    ConexaoBanco.executaComando($"DELETE FROM curso WHERE curso.titulo = '{titulo}'", false);
                    ConexaoBanco.executaComando($"DELETE FROM aula WHERE aula.id_curso_fk ='{idFKAula}'", false);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Curso> Listar()
        {
            List<Curso> listaCurso = new List<Curso>();
            DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso");

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string nome = $"{dt.Rows[i]["titulo"]}";
                    string titulo = $"{dt.Rows[i]["capa"]}";
                    string nomeProfessor = $"{dt.Rows[i]["nome_professor"]}";
                    string descricao = $"{dt.Rows[i]["descricao"]}";
                    int idFKAula = Convert.ToInt32($"{dt.Rows[0]["id_curso"]}");

                    DataTable dtAula = ConexaoBanco.retornaDados($"SELECT * FROM aula WHERE aula.id_curso_fk = {idFKAula}");

                    if (dtAula.Rows.Count > 0)
                    {
                        string tituloAula = $"{dtAula.Rows[0]["titulo"]}";
                        string linkAula = $"{dtAula.Rows[0]["link"]}";
                        string descricaoAula = $"{dtAula.Rows[0]["descricao"]}";
                        aula = new Aula(tituloAula, linkAula, descricaoAula);
                    }
                    curso = new Curso(nome, titulo, nomeProfessor, descricao, aula);

                    listaCurso.Add(curso);
                }
            }
            else
            {
                return null;
            }
            return listaCurso;
        }

        public Curso RetornaPorTitulo(string titulo)
        {
            DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.titulo = '{titulo}'");

            if (dt.Rows.Count > 0)
            {
                int idFKAula = Convert.ToInt32($"{dt.Rows[0]["id_curso"]}");
                string tituloCurso = $"{dt.Rows[0]["titulo"]}";
                string capa = $"{dt.Rows[0]["capa"]}";
                string nomeProfessor = $"{dt.Rows[0]["nome_professor"]}";
                string descricaoCurso = $"{dt.Rows[0]["descricao"]}";

                DataTable dtAula = ConexaoBanco.retornaDados($"SELECT * FROM aula WHERE aula.id_curso_fk = {idFKAula}");

                if (dtAula.Rows.Count > 0)
                {
                    string tituloAula = $"{dtAula.Rows[0]["titulo"]}";
                    string link = $"{dtAula.Rows[0]["link"]}";
                    string descricaoAula = $"{dtAula.Rows[0]["descricao"]}";
                    this.aula = new Aula(tituloAula, link, descricaoAula);
                }
                this.curso = new Curso(tituloCurso, capa, nomeProfessor, descricaoCurso, this.aula);
            }
            else
            {
                this.curso = null;
            }

            return this.curso;
        }

    }

}

