using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using GustavoFonseca.DesafioEstagio.DAL.Context;
using GustavoFonseca.DesafioEstagio.Domain;

namespace GustavoFonseca.DesafioEstagio.API.Controllers
{
    [RoutePrefix("api/Alunos")]
    public class AlunosController : ApiController
    {
        private Context db = new Context();

        // GET: api/Alunos
        public IList<Aluno> GetAlunos()
        {
            var retorno = db.Alunos.ToList();
            List<Aluno> Alunos = new List<Aluno>();
            foreach (var item in retorno)
            {
                var aluno = new Aluno();
                aluno.AlunoId = item.AlunoId;
                aluno.Nome = item.Nome;
                var turma = new Turma();
                turma.Nome = item.Turma.Nome;
                turma.TurmaId = item.Turma.TurmaId;
                turma.Ano = item.Turma.Ano;
                turma.Turno = item.Turma.Turno;
                aluno.Turma = turma;
                Alunos.Add(aluno);
            }
            return Alunos;
        }

        // GET: api/Alunos/5
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult GetAluno(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        // PUT: api/Alunos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAluno(int id, Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aluno.AlunoId)
            {
                return BadRequest();
            }

            db.Entry(aluno).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Alunos
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult PostAluno(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alunos.Add(aluno);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = aluno.AlunoId }, aluno);
        }

        // DELETE: api/Alunos/5
        [ResponseType(typeof(Aluno))]
        public IHttpActionResult DeleteAluno(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return NotFound();
            }

            db.Alunos.Remove(aluno);
            db.SaveChanges();

            return Ok(aluno);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlunoExists(int id)
        {
            return db.Alunos.Count(e => e.AlunoId == id) > 0;
        }
    }
}