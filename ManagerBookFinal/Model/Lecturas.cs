using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Model
{
    public class Lecturas
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("TemporadaLectura")]
        public int IDTemporadaLectura { get; set; }
        public TemporadaLectura TemporadaLectura { get; set; }

        [ForeignKey("Libro")]
        public int IDLibro { get; set; }
        public Libro Libro { get; set; }

        public string FechaInicial { get; set; }
        public string FechaFinal { get; set; }
        public long HoraInicial { get; set; }
        public long HoraFinal { get; set; }
        public int CapitulosDeHoy { get; set; }
        public int PaginasDeHoy { get; set; }

        public List<NotaLectura> NotaLecturas { get; set; }
    }
}
