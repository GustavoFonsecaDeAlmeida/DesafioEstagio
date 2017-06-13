using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GustavoFonseca.DesafioEstagio.Domain
{
    [Table("Professores")]
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Nome { get; set; }

        
    }
}
