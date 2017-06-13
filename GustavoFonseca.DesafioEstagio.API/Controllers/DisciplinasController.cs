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
    public class DisciplinasController : ApiController
    {
        private Context db = new Context();

        // GET: api/Disciplinas
        public IList<Disciplina> GetDisciplinas()
        {
            var retorno =  db.Disciplinas.ToList();
            List<Disciplina> disciplinas = new List<Disciplina>();
            foreach (var item in retorno)
            {
                var disciplina = new Disciplina();
                disciplina.DisciplinaId = item.DisciplinaId;
                disciplina.Nome = item.Nome;
                disciplina.professor = item.professor;
                var turmas = new List<Turma>();
                foreach (var item2 in item.Turmas)
                {
                    var turma = new Turma();
                    turma.Ano = item2.Ano;
                    turma.Nome = item2.Ano;
                    turma.TurmaId = item2.TurmaId;
                    turma.Turno = item2.Turno;
                    turmas.Add(turma);
                }
                disciplinas.Add(disciplina);
            }
            return disciplinas;
            
           
        }

        // GET: api/Disciplinas/5
        [ResponseType(typeof(Disciplina))]
        public IHttpActionResult GetDisciplina(int id)
        {
            Disciplina disciplina = db.Disciplinas.Find(id);
            if (disciplina == null)
            {
                return NotFound();
            }

            return Ok(disciplina);
        }

        // PUT: api/Disciplinas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDisciplina(int id, Disciplina disciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disciplina.DisciplinaId)
            {
                return BadRequest();
            }

            db.Entry(disciplina).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplinaExists(id))
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

        // POST: api/Disciplinas
        [ResponseType(typeof(Disciplina))]
        public IHttpActionResult PostDisciplina(Disciplina disciplina)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Disciplinas.Add(disciplina);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = disciplina.DisciplinaId }, disciplina);
        }

        // DELETE: api/Disciplinas/5
        [ResponseType(typeof(Disciplina))]
        public IHttpActionResult DeleteDisciplina(int id)
        {
            Disciplina disciplina = db.Disciplinas.Find(id);
            if (disciplina == null)
            {
                return NotFound();
            }

            db.Disciplinas.Remove(disciplina);
            db.SaveChanges();

            return Ok(disciplina);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DisciplinaExists(int id)
        {
            return db.Disciplinas.Count(e => e.DisciplinaId == id) > 0;
        }
    }
}