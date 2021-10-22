using Dindin.Inteface;
using Dindin.Model;
using Dindin.Web.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Dindin.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IRepositorio _repositorio;

        public CursoController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        CursoModel modelCuso = new CursoModel();
        AulaModel modelAula = new AulaModel();
        List<AulaModel> listModelAula = new List<AulaModel>();
        List<Aula> listModel = new List<Aula>();

        [HttpGet("")]
        public IActionResult GetCursos()
        {
            List<Curso> verificaLista = _repositorio.GetCursos();

            if (verificaLista != null)
            return Ok(_repositorio.GetCursos().Select(c => new CursoModel(c)));
            return NotFound($"Nenhum curso cadastrado.");
        }
                
        [HttpGet("{id}")]
        public IActionResult GetCursoID(int id)
        {
            Curso curso = _repositorio.GetCursoID(id);

            if (curso != null)
            {
                this.modelCuso.ID = curso.retornaID();
                this.modelCuso.Titulo = curso.retornaTitulo();
                this.modelCuso.Capa = curso.retornaCapa();
                this.modelCuso.NomeProfessor = curso.retornaNomeProfessor();
                this.modelCuso.Descricao = curso.retornaDescricao();
                return Ok(this.modelCuso);
            }
            return NotFound($"Nenhum curso cadastrado referente ao id = {id}.");
        }     

        [HttpGet("AulasDoCurso/{id}")]
        public IActionResult GetAulasByCursoID(int id)
        {
            List<Aula> verificaLista = _repositorio.GetAulasByCursoID(id);

            if (verificaLista != null)
            return Ok(_repositorio.GetAulasByCursoID(id).Select(a => new AulaModel(a)));
            return NotFound($"Nenhuma aula cadastrada referente ao id = {id}.");
        }

        [HttpPost("")]
        public IActionResult CreateCurso([FromBody] object curso)
        {
            dynamic data = JObject.Parse(curso.ToString());

            if (curso != null)
            {
                this.modelCuso.Titulo = data.titulo;
                this.modelCuso.Capa = data.capa;
                this.modelCuso.NomeProfessor = data.nomeProfessor;
                this.modelCuso.Descricao = data.descricao;
                bool result = _repositorio.CreateCurso(modelCuso.ToCurso());

                if (result) return Created("", null);
                else return NotFound($"Curso não foi cadastrado.");
            }
            return BadRequest("Request inválido");
        }

        [HttpPost("AulaDoCurso")]
        public IActionResult CreateAulaByCursoTitulo(string tituloCurso, [FromBody] List<object> list)
        {
            string newTitulo = Regex.Replace(tituloCurso, "-", " ");

            if (newTitulo != null && list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    dynamic data = JObject.Parse(list[i].ToString());
                    this.modelAula.Titulo = data.titulo;
                    this.modelAula.Link = data.link;
                    this.modelAula.Descricao = data.descricao;
                    this.listModel.Add(this.modelAula.ToAula());
                }
                bool result = _repositorio.CreateAulaByCursoTitulo(newTitulo, listModel);

                if (result) return Created("", null);
                else return NotFound($"Aula não foi cadastrada.");
            }
            return BadRequest("Request inválido");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCurso(int id, [FromBody] object curso)
        {
            if (curso != null)
            {
                dynamic data = JObject.Parse(curso.ToString());
                this.modelCuso.Titulo = data.titulo;
                this.modelCuso.Capa = data.capa;
                this.modelCuso.NomeProfessor = data.nomeProfessor;
                this.modelCuso.Descricao = data.descricao;
                bool result = _repositorio.UpdateCurso(id, modelCuso.ToCurso());

                if (result) return Ok($"Curso atualizado com sucesso.");
                else return NotFound($"Curso não encontrado.");
            }
            return BadRequest("Request inválido");
        }

        [HttpPut("AulaDoCurso")]
        public IActionResult UpdateAulasByCursoID(int id, string tituloAula, [FromBody] List<object> list)
        {
            string newAula = Regex.Replace(tituloAula, "-", " ");

            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    dynamic data = JObject.Parse(list[i].ToString());
                    this.modelAula.Titulo = data.titulo;
                    this.modelAula.Link = data.link;
                    this.modelAula.Descricao = data.descricao;
                    this.listModel.Add(this.modelAula.ToAula());
                }
                bool result = _repositorio.UpdateAulasByCursoTitulo(id, newAula, listModel);

                if (result) return Ok($"Aula atualizada com sucesso.");
                else return NotFound($"Aula não encontrada.");
            }
            return BadRequest("Request inválido");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCurso(int id)
        {
            bool result = _repositorio.DeleteCurso(id);

            if (result) return Ok($"Curso referente ao id = {id} removido com sucesso.");
            else return NotFound($"Curso referente ao id = {id} não encontrado.");
        }

       [HttpDelete("AulaDoCurso")]
        public IActionResult DeleteAulaByCursoID(int id, string tituloAula)
        {
            string newTitulo = Regex.Replace(tituloAula, "-", " ");
            bool result = _repositorio.DeleteAulaByCursoID(id, newTitulo);

            if (result) return Ok($"Aula referente ao id = {id} removida com sucesso.");
            else return NotFound($"Aula do curso referente ao id = {id} não encontrada.");
        }
    }
}
