using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GustavoFonseca.DesafioEstagio.Domain
{
    [Table("Disciplinas")]
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        public Professor professor { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }

    }
}
