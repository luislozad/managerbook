using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Module.Helper
{
    public static class Lecturas
    {
        public static List<Model.Lecturas> GetLecturaTrunco(int temporadaID, int bookID)
        {
            using Database.Context database = new();

            var tempReadingM = GetTemporadaLecturaAll(temporadaID);
            
            List<Model.Lecturas> readingM = new();

            tempReadingM.ForEach(tempR =>
            {
                var readingList = GetLectura(tempR.ID, bookID);

                readingList.ForEach(r => readingM.Add(r));
            });


            return readingM;
        }

        public static List<Model.Lecturas> GetLectura(int temporadaLecturaID, int bookID)
        {
            using Database.Context database = new();

            return database
                    .Lecturas
                    .Where(read => read.IDTemporadaLectura == temporadaLecturaID && read.IDLibro == bookID && read.FechaFinal != null)
                    .OrderBy(read => read.ID)
                    .ToList();
        }

        public static List<Model.Lecturas> GetLecturaAll(int temporadaLecturaID)
        {
            using Database.Context database = new();

            return database
                    .Lecturas
                    .Where(read => read.IDTemporadaLectura == temporadaLecturaID && read.FechaFinal != null)
                    .OrderBy(read => read.ID)
                    .ToList();
        }

        public static List<Model.TemporadaLectura> GetTemporadaLecturaAll(int temporadID)
        {
            using Database.Context database = new();

            return database
                    .TemporadaLecturas
                    .Where(temp => temp.IDTemporada == temporadID)
                    .OrderBy(temp => temp.ID)
                    .ToList();
        }

        public static Model.TemporadaLectura GetTemporadaLecturaIncomplete(int temporadID)
        {
            using Database.Context database = new();

            return database
                    .TemporadaLecturas
                    .SingleOrDefault(temp => temp.IDTemporada == temporadID && temp.FechaFinal == null);
        }
    }
}
