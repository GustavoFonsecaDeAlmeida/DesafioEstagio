using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GustavoFonseca.DesafioEstagio.Domain
{
    [Table("Alunos")]
    public class Aluno
    {
        public int AlunoId { get; set; }

        public string Nome { get; set; }


        public virtual Turma Turma { get; set; }

    }
}
