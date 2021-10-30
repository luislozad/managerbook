using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Module.Helper
{
    public static class Libro
    {
        public static int CalcPagByDay(List<Model.Lecturas> reading)
        {
            if (reading.Count > 0)
            {
                int pagTotal = 0;
                int pagSize = 0;

                reading.ForEach(readM =>
                {
                    if (readM.PaginasDeHoy > 0)
                    {
                        pagTotal += readM.PaginasDeHoy;
                        pagSize++;
                    }
                });

                return pagSize > 0 ? (int)Math.Round((decimal)pagTotal / pagSize) : 0;
            }
            else
            {
                return 0;
            }
        }

        public static int CalcCapByWeek(List<Model.Lecturas> reading)
        {
            if (reading.Count > 0)
            {
                int capTotal = 0;
                decimal weekTotal = 0;
                decimal weekSize = 0;

                reading.ForEach(readM =>
                {
                    if (readM.CapitulosDeHoy > 0)
                    {
                        capTotal += readM.CapitulosDeHoy;
                        weekTotal++;
                    }
                });

                decimal week = 7;

                weekSize = weekTotal / week;

                return weekSize > 0 ? (int)Math.Round(capTotal / weekSize) : capTotal;
            }
            else
            {
                return 0;
            }
        }

        public static int CalcHourByDay(List<Model.Lecturas> reading)
        {
            int hourResult = 0;

            if (reading.Count > 0)
            {
                int hourTotal = 0;
                int hourSize = 0;

                reading.ForEach(readM =>
                {
                    int hourStart = Time.GetHourTimeUnix(readM.HoraInicial);
                    int hourEnd = Time.GetHourTimeUnix(readM.HoraFinal);

                    int hours = hourEnd - hourStart;

                    if (hours > 0)
                    {
                        hourTotal += hours;
                        hourSize++;
                    }
                });

                hourResult = hourSize > 0 ? (int)Math.Round((decimal)hourTotal / hourSize) : 0;

                return hourResult;
            }
            else
            {
                return hourResult;
            }
        }

        public static string GetDateLastRealBook(List<Model.Lecturas> reading, int libroID)
        {
            const string FORMAT_DATE = "dd/MM/yyyy";

            using Database.Context database = new();

            int pagByDay = CalcPagByDay(reading);
            int totalDay = CalcTotalDay(libroID);

            var libro = database.Libros.Single(book => book.ID == libroID);

            int totalPag = libro.Pages - libro.PagesCompl;

            if (totalPag > 0 && pagByDay > 0)
            {
                int newTotalPag = pagByDay * totalDay;

                int resultTotalPag = totalPag - newTotalPag;

                if (resultTotalPag > 0)
                {
                    int days = resultTotalPag / pagByDay;

                    return DateTime.Parse(libro.LastDate).AddDays(days).ToString(FORMAT_DATE);
                }
                else
                {
                    int days = Math.Abs(resultTotalPag) / pagByDay;

                    var resultDate = DateTime.Parse(libro.LastDate).AddDays(-days);

                    return resultDate.ToString(FORMAT_DATE);
                }
            }
            else
            {
                string lastDate = null;

                reading.ForEach(readM =>
                {
                    if (readM.FechaFinal != null)
                    {
                        lastDate = readM.FechaFinal;
                    }
                });

                return lastDate;
            }
        }

        public static int CalcTotalDay(int libroID)
        {
            using Database.Context database = new();
            var libro = database.Libros.Single(book => book.ID == libroID);

            //var startDateRaw = DateTime.Parse(libro.StartDate);
            var lastDateRaw = DateTime.Parse(libro.LastDate);

            var currentDateRaw = DateTime.Parse(DateTime.Now.ToString());

            double totalDays = (lastDateRaw - currentDateRaw).TotalDays;

            return (int)Math.Round(totalDays);
        }

    }
}
