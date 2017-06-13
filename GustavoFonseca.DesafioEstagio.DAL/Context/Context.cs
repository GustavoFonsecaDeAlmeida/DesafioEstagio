using GustavoFonseca.DesafioEstagio.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GustavoFonseca.DesafioEstagio.DAL.Context
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {
            

        }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        
       
    }
}
