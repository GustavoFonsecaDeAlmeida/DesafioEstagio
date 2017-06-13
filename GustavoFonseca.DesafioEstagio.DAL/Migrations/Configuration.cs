namespace GustavoFonseca.DesafioEstagio.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GustavoFonseca.DesafioEstagio.DAL.Context.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "GustavoFonseca.DesafioEstagio.DAL.Context.Context";
        }

        protected override void Seed(GustavoFonseca.DesafioEstagio.DAL.Context.Context context)
        {
  

            context.Turmas.AddOrUpdate(x => x.TurmaId,
                new Domain.Turma() { TurmaId = 1, Nome = "Ingles", Ano = "2017", Turno = "Manha" },
                new Domain.Turma() { TurmaId = 2, Nome = "Turco", Ano = "2017", Turno = "Manha" },
                new Domain.Turma() { TurmaId = 3, Nome = "Polones", Ano = "2017", Turno = "Noite"}  
                );

            context.Professores.AddOrUpdate(x => x.ProfessorId,
                new Domain.Professor() { ProfessorId = 1 , Nome = "Gustavo"},
                new Domain.Professor() { ProfessorId = 1, Nome = "Rodrigo" }
                );

            context.Disciplinas.AddOrUpdate(x => x.DisciplinaId,
                new Domain.Disciplina() { DisciplinaId = 1, Nome = "Ingles Tecnico", professor = new Domain.Professor() { ProfessorId = 1, Nome = "Gustavo" } },
                new Domain.Disciplina() { DisciplinaId = 1, Nome = "Ingles Avançado", professor = new Domain.Professor() { ProfessorId = 1, Nome = "Gustavo" } },
                new Domain.Disciplina() { DisciplinaId = 1, Nome = "Turco Iniciante", professor = new Domain.Professor() { ProfessorId = 2, Nome = "Rodrigo" } }
                );

            context.Alunos.AddOrUpdate(x => x.AlunoId,
                new Domain.Aluno() { AlunoId = 1, Nome = "Afonso", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Eduardo", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Katrina", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Afonso", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Thiago", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Thamyres", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Thalita", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Andre", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Jessica", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Denise", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Roberto", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Ramon", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Hygor", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Nilson", Turma = context.Turmas.Find(1) },
                new Domain.Aluno() { AlunoId = 1, Nome = "Larissa", Turma = context.Turmas.Find(1) }

                );


        }
    }
}
