using GustavoFonseca.DesafioEstagio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GustavoFonseca.DesafioEstagio.DAL
{
    public class TurmaDAO
    {
        DAL.Context.Context contexto = new DAL.Context.Context();

        public bool Adicionar(Turma turma)
        {
            contexto.Turmas.Add(turma);
            contexto.SaveChanges();
            return true;
        }
        public bool Remover(int idTurma)
        {
            var turma = Selecionar(idTurma);
            contexto.Turmas.Remove(turma);
            contexto.SaveChanges();
            return true;
        }
        public Turma Selecionar(int idTurma)
        {
            var turma = contexto.Turmas.Find(idTurma);
            return turma;
        }
        public bool Editar(int idTurma , Turma turma)
        {
            var turmaAntiga = Selecionar(idTurma);
            turmaAntiga.TurmaId = turma.TurmaId;
            turmaAntiga.Nome = turma.Nome;
            turmaAntiga.Turno = turma.Turno;
            turmaAntiga.Disciplinas = turma.Disciplinas;
            turmaAntiga.Alunos = turma.Alunos;
            contexto.SaveChanges();
            return true;
        }
    }
}
