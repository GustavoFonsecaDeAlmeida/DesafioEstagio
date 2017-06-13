using GustavoFonseca.DesafioEstagio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GustavoFonseca.DesafioEstagio.DAL
{
    public class ProfessorDAO
    {
        DAL.Context.Context contexto = new DAL.Context.Context();
        public bool Adicionar(Professor professor)
        {
            contexto.Professores.Add(professor);
            contexto.SaveChanges();
            return true;
        }
        public bool Remover(int idProfessor)
        {
            var professor = Selecionar(idProfessor);
            contexto.Professores.Remove(professor);
            contexto.SaveChanges();
            return true;
        }
        public Professor Selecionar(int idProfessor)
        {
            var professor = contexto.Professores.Find(idProfessor);
            return professor;
        }
        public bool Editar(int idProfessor , Professor professor)
        {
            var professorAntigo = Selecionar(idProfessor);
            professorAntigo.Nome = professor.Nome;
            professorAntigo.ProfessorId = professor.ProfessorId;
            contexto.SaveChanges();
            return true;
        }
    }
}
