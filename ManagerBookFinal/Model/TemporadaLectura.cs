using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Model
{
    public class TemporadaLectura
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Temporada")]
        public int IDTemporada { get; set; }
        public Temporada Temporada { get; set; }

        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }

        public List<Lecturas> ListaDeLecturas { get; set; }
    }
}
