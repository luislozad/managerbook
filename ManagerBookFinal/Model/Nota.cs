using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Model
{
    public class Nota
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }

        [ForeignKey("Libro")]
        public int IDBook { get; set; }
        public Libro Libro { get; set; }
    }
}
