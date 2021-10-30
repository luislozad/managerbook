using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerBookFinal.Interface;

namespace ManagerBookFinal.Module
{
    public class DataB: IObjectID
    {
        private int ID = -1;
        private string Title, URL, LastDate, StartDate, ImageLocation, LastReadingDate, LastDateSystem;
        private int Capitulos, CapitulosCompl, Paginas, PaginasCompl;
        private int PagByDay, CapByWeek;
        private long HourByDay;

        private readonly List<DataN> Notes = new();

        private const string FORMAT_DATE = "dd/MM/yyyy";

        public DataB() { }

        public void SetStartDate(string startDate)
        {
            StartDate = startDate;
        }

        public string GetStartDate()
        {
            return StartDate;
        }

        public void SetLastDateSystem(string lastDateSystem)
        {
            LastDateSystem = lastDateSystem;
        }

        public string GetLastDateSystem()
        {
            return LastDateSystem;
        }

        public void SetPagByDay(int pagByDay)
        {
            PagByDay = pagByDay;
        }

        public int GetPagByDay()
        {
            return PagByDay;
        }

        public void SetCapByWeek(int capByWeek)
        {
            CapByWeek = capByWeek;
        }

        public int GetCapByWeek()
        {
            return CapByWeek;
        }

        public void SetHourByDay(long hourByDay)
        {
            HourByDay = hourByDay;
        }

        public long GetHourByDay()
        {
            return HourByDay;
        }

        public void SetImageLocation(string imageLocation)
        {
            ImageLocation = imageLocation;
        }

        public string GetImageLocation()
        {
            return ImageLocation;
        }

        public void SetID(int id)
        {
            ID = id;
        }

        public int GetID()
        {
            return ID;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public string GetTitle()
        {
            return Title;
        }

        public void SetURL(string url)
        {
            URL = url;
        }

        public string GetURL()
        {
            return URL;
        }

        public void SetLastDate(string date)
        {
            LastDate = date;
        }

        public string GetLastDate()
        {
            return Convert.ToDateTime(LastDate).ToString(FORMAT_DATE);
        }

        public void SetLastReadingDate(string date)
        {
            LastReadingDate = date;
        }

        public string GetLastReadingDate()
        {
            if (LastReadingDate != null && LastReadingDate != "")
            {
                return Convert.ToDateTime(LastReadingDate).ToString(FORMAT_DATE);
            }
            else
            {
                return null;
            }
        }

        public void SetCapitulos(int caps)
        {
            Capitulos = caps;
        }

        public int GetCapitulos()
        {
            return Capitulos;
        }

        public void SetCapitulosCompl(int capsCompl)
        {
            CapitulosCompl = capsCompl;
        }

        public int GetCapitulosCompl()
        {
            return CapitulosCompl;
        }

        public void SetPaginas(int pags)
        {
            Paginas = pags;
        }

        public int GetPaginas()
        {
            return Paginas;
        }

        public void SetPaginasCompl(int pagsCompl)
        {
            PaginasCompl = pagsCompl;
        }

        public int GetPaginasCompl()
        {
            return PaginasCompl;
        }

        public void AddNote(DataN notes)
        {
            Notes.Add(notes);
        }

        public IReadOnlyCollection<DataN> GetNotes()
        {
            return Notes.AsReadOnly();
        }

        public void CleanNotes()
        {
            Notes.Clear();
        }
    }
}
