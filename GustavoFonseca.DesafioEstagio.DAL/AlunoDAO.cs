using GustavoFonseca.DesafioEstagio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GustavoFonseca.DesafioEstagio.DAL
{
    public class AlunoDAO
    {

        DAL.Context.Context contexto = new DAL.Context.Context();

        public bool Adicionar(Aluno aluno)
        {
            contexto.Alunos.Add(aluno);
            contexto.SaveChanges();
            return true;
        }
        public bool Remover(int idAluno)
        {
            var aluno = Selecionar(idAluno);
            contexto.Alunos.Remove(aluno);
            contexto.SaveChanges();
            return true;
        }
        public Aluno Selecionar(int idAluno)
        {
            var aluno = contexto.Alunos.Find(idAluno);
            return aluno;
        }
        public bool Editar(int idAluno , Aluno aluno)
        {
            var alunoAntigo = Selecionar(idAluno);
            alunoAntigo.AlunoId = aluno.AlunoId;
            alunoAntigo.Nome = aluno.Nome;
            alunoAntigo.Turma = aluno.Turma;
            contexto.SaveChanges();
            return true;
        }
    }
}
