using ManagerBookFinal.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Model
{
    public class Temporada
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImageLocation { get; set; }
        public string StartDate { get; set; }
        public string LastDate { get; set; }
        public int Books { get; set; }
        public int BooksCompl { get; set; }
        public int Pages { get; set; }
        public int PagesCompl { get; set; }
        
        public List<Libro> BookList { get; set; }
    }
}
