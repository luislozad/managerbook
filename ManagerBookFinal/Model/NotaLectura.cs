using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Model
{
    public class NotaLectura
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Lecturas")]
        public int IDLecturas { get; set; }

        public Lecturas Lecturas { get; set; }

        [ForeignKey("Nota")]
        public int IDNota { get; set; }

        public Nota Nota { get; set; }
    }
}
