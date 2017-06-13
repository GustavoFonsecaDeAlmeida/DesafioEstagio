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
    public class TurmasController : ApiController
    {
        private Context db = new Context();

        // GET: api/Turmas
        //Alguns valores estao nullos para evitar loop , podera ser tratado em um query diferente se for o caso.
        public IList<Turma> GetTurmas()
        {
            var retorno = db.Turmas.ToList();
            List<Turma> Turmas = new List<Turma>();
            foreach (var item in retorno)
            {
                var turma = new Turma()
                {
                    TurmaId = item.TurmaId,
                    Nome = item.Nome,
                    Ano = item.Ano,
                    Turno = item.Turno,
                    Alunos = new List<Aluno>(),
                    Disciplinas = new List<Disciplina>()


                };
                foreach (var item2 in item.Alunos)
                {
                    var aluno = new Aluno();
                    aluno.Nome = item2.Nome;
                    aluno.AlunoId = item2.AlunoId;
                    
                    

                    turma.Alunos.Add(aluno);

                }

                foreach (var item3 in item.Disciplinas)
                {
                    var Disciplina = new Disciplina();
                    Disciplina.DisciplinaId = item3.DisciplinaId;
                    Disciplina.Nome = item3.Nome;
                    
                   
                    
                    
                  


                    turma.Disciplinas.Add(Disciplina);

                }
                Turmas.Add(turma);

            }
            return Turmas;
        }

        // GET: api/Turmas/5
        [ResponseType(typeof(Turma))]
        public IHttpActionResult GetTurma(int id)
        {
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
            {
                return NotFound();
            }
            

            return Ok(turma);
        }

        // PUT: api/Turmas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTurma(int id, Turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != turma.TurmaId)
            {
                return BadRequest();
            }

            db.Entry(turma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
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

        // POST: api/Turmas
        [ResponseType(typeof(Turma))]
        public IHttpActionResult PostTurma(Turma turma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Turmas.Add(turma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = turma.TurmaId }, turma);
        }

        // DELETE: api/Turmas/5
        [ResponseType(typeof(Turma))]
        public IHttpActionResult DeleteTurma(int id)
        {
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
            {
                return NotFound();
            }

            db.Turmas.Remove(turma);
            db.SaveChanges();

            return Ok(turma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TurmaExists(int id)
        {
            return db.Turmas.Count(e => e.TurmaId == id) > 0;
        }
    }
}