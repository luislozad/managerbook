using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerBookFinal.Interface;

namespace ManagerBookFinal.Module
{
    public class DataR: IObjectID
    {
        private string Title, Link, ImageLocation, StartDate, LastDateLimit, LastDateSystem;
        private string DateStart, DateEnd, DateLastReading;
        private int CapTotal, CapTotalCompl, PagTotal, PagTotalCompl;
        private int CapToday, PagToday;
        private long HourStart, HourEnd;
        private int CapByWeek, PagByDay;
        private long HourByDay;

        private List<DataN> Notes = new();

        private int ID = -1;

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

        public void SetDateLastReading(string dateLastReading)
        {
            DateLastReading = dateLastReading;
        }

        public string GetDateLastReading()
        {
            return DateLastReading;
        }

        public string GetTitle()
        {
            return Title;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public string GetLink()
        {
            return Link;
        }

        public void SetLink(string link)
        {
            Link = link;
        }

        public string GetDateStart()
        {
            return DateStart;
        }

        public void SetDateStart(string dateStart)
        {
            DateStart = dateStart;
        }

        public long GetHourStart()
        {
            return HourStart;
        }

        public void SetHourStart(long hourStart)
        {
            HourStart = hourStart;
        }

        public string GetDateEnd()
        {
            return DateEnd;
        }

        public void SetDateEnd(string dateEnd)
        {
            DateEnd = dateEnd;
        }

        public int GetCapTotal()
        {
            return CapTotal;
        }

        public void SetCapTotal(int capTotal)
        {
            CapTotal = capTotal;
        }

        public int GetCapTotalCompl()
        {
            return CapTotalCompl;
        }

        public void SetCapTotalCompl(int capTotalCompl)
        {
            CapTotalCompl = capTotalCompl;
        }

        public int GetPagTotal()
        {
            return PagTotal;
        }

        public void SetPagTotal(int pagTotal)
        {
            PagTotal = pagTotal;
        }

        public int GetPagTotalCompl()
        {
            return PagTotalCompl;
        }

        public void SetPagTotalCompl(int pagTotalCompl)
        {
            PagTotalCompl = pagTotalCompl;
        }

        public int GetCapToday()
        {
            return CapToday;
        }

        public void SetCapToday(int capToday)
        {
            CapToday = capToday;
        }

        public int GetPagToday()
        {
            return PagToday;
        }

        public void SetPagToday(int pagToday)
        {
            PagToday = pagToday;
        }

        public long GetHourEnd()
        {
            return HourEnd;
        }

        public void SetHourEnd(long hourEnd)
        {
            HourEnd = hourEnd;
        }

        public void SetID(int id)
        {
            ID = id;
        }

        public int GetID()
        {
            return ID;
        }

        public void SetImageLocation(string imageLocation)
        {
            ImageLocation = imageLocation;
        }

        public string GetImageLocation()
        {
            return ImageLocation;
        }

        public List<DataN> GetNotes()
        {
            return Notes;
        }

        public void SetNotes(List<DataN> notes)
        {
            Notes = notes;
        }

        public void SetLastDateLimit(string lastDate)
        {
            LastDateLimit = lastDate;
        }

        public string GetLastDateLimit()
        {
            return LastDateLimit;
        }
    }
}
