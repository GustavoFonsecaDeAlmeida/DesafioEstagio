namespace GustavoFonseca.DesafioEstagio.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        AlunoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Turma_TurmaId = c.Int(),
                    })
                .PrimaryKey(t => t.AlunoId)
                .ForeignKey("dbo.Turmas", t => t.Turma_TurmaId)
                .Index(t => t.Turma_TurmaId);
            
            CreateTable(
                "dbo.Turmas",
                c => new
                    {
                        TurmaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Turno = c.String(),
                        Ano = c.String(),
                    })
                .PrimaryKey(t => t.TurmaId);
            
            CreateTable(
                "dbo.Disciplinas",
                c => new
                    {
                        DisciplinaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        professor_ProfessorId = c.Int(),
                    })
                .PrimaryKey(t => t.DisciplinaId)
                .ForeignKey("dbo.Professores", t => t.professor_ProfessorId)
                .Index(t => t.professor_ProfessorId);
            
            CreateTable(
                "dbo.Professores",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.ProfessorId);
            
            CreateTable(
                "dbo.DisciplinaTurmas",
                c => new
                    {
                        Disciplina_DisciplinaId = c.Int(nullable: false),
                        Turma_TurmaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Disciplina_DisciplinaId, t.Turma_TurmaId })
                .ForeignKey("dbo.Disciplinas", t => t.Disciplina_DisciplinaId, cascadeDelete: true)
                .ForeignKey("dbo.Turmas", t => t.Turma_TurmaId, cascadeDelete: true)
                .Index(t => t.Disciplina_DisciplinaId)
                .Index(t => t.Turma_TurmaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DisciplinaTurmas", "Turma_TurmaId", "dbo.Turmas");
            DropForeignKey("dbo.DisciplinaTurmas", "Disciplina_DisciplinaId", "dbo.Disciplinas");
            DropForeignKey("dbo.Disciplinas", "professor_ProfessorId", "dbo.Professores");
            DropForeignKey("dbo.Alunos", "Turma_TurmaId", "dbo.Turmas");
            DropIndex("dbo.DisciplinaTurmas", new[] { "Turma_TurmaId" });
            DropIndex("dbo.DisciplinaTurmas", new[] { "Disciplina_DisciplinaId" });
            DropIndex("dbo.Disciplinas", new[] { "professor_ProfessorId" });
            DropIndex("dbo.Alunos", new[] { "Turma_TurmaId" });
            DropTable("dbo.DisciplinaTurmas");
            DropTable("dbo.Professores");
            DropTable("dbo.Disciplinas");
            DropTable("dbo.Turmas");
            DropTable("dbo.Alunos");
        }
    }
}
