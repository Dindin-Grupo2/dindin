using Dindin.DAO;
using Dindin.Interface;
using Dindin.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace Dindin.Classes
{
    public class CursoRepositorio
    {
        private Curso curso;
        private Aula aula;

        public bool Inserir(Curso curso, List<Aula> listaAula)
        {
            try
            {
                int? idFK = ConexaoBanco.executaComando($"INSERT INTO curso (titulo, capa, nome_professor, descricao) VALUES ('{curso.retornaTitulo()}', '{curso.retornaCapa()}', '{curso.retornaNomeProfessor()}', '{curso.retornaDescricao()}')", true);

                foreach (var aula in listaAula)
                {
                    ConexaoBanco.executaComando($"INSERT INTO aula (id_curso_fk, titulo, link, descricao) values ({idFK}, '{aula.retornaTitulo()}', '{aula.retornaLink()}','{aula.retornaDescricao()}')", false);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Atualizar(string titulo, Curso curso, List<Aula> listaAula)
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

                    foreach (var aula in listaAula)
                    {
                        ConexaoBanco.executaComando(@$"UPDATE aula 
                                           SET titulo = '{aula.retornaTitulo()}',
                                           link = '{aula.retornaLink()}',
                                           descricao = '{aula.retornaDescricao()}'
                                           WHERE id_curso_fk = {idFKAula} AND titulo = '{aula.retornaTitulo()}'" , false);
                    }
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
                    ConexaoBanco.executaComando($"DELETE FROM aula WHERE aula.id_curso_fk ='{idFKAula}' AND titulo = '{aula.retornaTitulo()}'", false);
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
                    string titulo = $"{dt.Rows[i]["titulo"]}";
                    string capa = $"{dt.Rows[i]["capa"]}";
                    string nomeProfessor = $"{dt.Rows[i]["nome_professor"]}";
                    string descricao = $"{dt.Rows[i]["descricao"]}";
                    curso = new Curso(titulo, capa, nomeProfessor, descricao);

                    listaCurso.Add(curso);
                }
            }
            else
            {
                return null;
            }
            return listaCurso;
        }

        public Curso RetornaPorTituloCurso(string titulo)
        {
            DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.titulo= '{titulo}'");

            if (dt.Rows.Count > 0)
            {
                string tituloCurso = $"{dt.Rows[0]["titulo"]}";
                string capa = $"{dt.Rows[0]["capa"]}";
                string nomeProfessor = $"{dt.Rows[0]["nome_professor"]}";
                string descricaoCurso = $"{dt.Rows[0]["descricao"]}";
                this.curso = new Curso(tituloCurso, capa, nomeProfessor, descricaoCurso);
            }
            else
            {
                return null;
            }
            return this.curso;
        }

        public List<Aula> RetornaPorTituloAula(string titulo)
        {
            List<Aula> listaAula = new List<Aula>();
            DataTable dt = ConexaoBanco.retornaDados($"SELECT * FROM curso WHERE curso.titulo= '{titulo}'");

            if (dt.Rows.Count > 0)
            {
                int idFKAula = Convert.ToInt32($"{dt.Rows[0]["id_curso"]}");
                DataTable dtAula = ConexaoBanco.retornaDados($"SELECT * FROM aula WHERE aula.id_curso_fk = {idFKAula}");

                if (dtAula.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string tituloAula = $"{dtAula.Rows[0]["titulo"]}";
                        string link = $"{dtAula.Rows[0]["link"]}";
                        string descricaoAula = $"{dtAula.Rows[0]["descricao"]}";
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

