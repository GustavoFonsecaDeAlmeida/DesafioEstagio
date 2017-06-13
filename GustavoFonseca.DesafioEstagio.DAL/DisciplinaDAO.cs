using GustavoFonseca.DesafioEstagio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GustavoFonseca.DesafioEstagio.DAL
{
    public class DisciplinaDAO
    {
        DAL.Context.Context contexto = new DAL.Context.Context();

        public bool Adicionar(Disciplina disciplina)
        {
            contexto.Disciplinas.Add(disciplina);
            contexto.SaveChanges();
            return true;
        }
        public bool Remover(int idDisciplina)
        {
            var disciplina = Selecionar(idDisciplina);
            contexto.Disciplinas.Remove(disciplina);
            contexto.SaveChanges();
            return true;
        }
        public Disciplina Selecionar(int idDisciplina)
        {
            var disciplina = contexto.Disciplinas.Find(idDisciplina);
            return disciplina;
        }
        public bool Editar(int idDisciplina , Disciplina disciplina)
        {
            var disciplinaAntiga = Selecionar(idDisciplina);
            disciplinaAntiga.DisciplinaId = disciplina.DisciplinaId;
            disciplinaAntiga.Nome = disciplina.Nome;
            disciplinaAntiga.professor = disciplina.professor;
            disciplinaAntiga.Turmas = disciplina.Turmas;
            contexto.SaveChanges();
            return true;
        }
    }
}
