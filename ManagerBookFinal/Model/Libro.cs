using ManagerBookFinal.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Model
{
    public class Libro
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImageLocation { get; set; }
        public string StartDate { get; set; }
        public string LastDate { get; set; }
        public string LastReadingDate { get; set; }
        public string Url { get; set; }
        public int Chapters { get; set; }
        public int ChaptersCompl { get; set; }
        public int Pages { get; set; }
        public int PagesCompl { get; set; }
        public int Time { get; set; }
        
        [ForeignKey("Temporada")]
        public int IDTemporada { get; set; }
        public Temporada Temporada { get; set; }

        public List<Nota> Notes { get; set; }
    }
}
