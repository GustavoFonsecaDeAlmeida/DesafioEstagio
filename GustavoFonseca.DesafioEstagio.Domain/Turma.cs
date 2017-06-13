using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GustavoFonseca.DesafioEstagio.Domain
{
    [Table("Turmas")]
    public class Turma
    {
        public int TurmaId { get; set; }

        public string Nome { get; set; }

        public string Turno { get; set; }

        public string Ano { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }

        public virtual ICollection<Disciplina> Disciplinas { get; set; }
    }
}
