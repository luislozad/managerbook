using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerBookFinal.Interface;

namespace ManagerBookFinal.Module
{
    public class DataT: IObjectID
    {
        private int ID = -1;
        private string Title, ImageLocation, LastDate, StartDate;
        private const string FORMAT_DATE = "dd/MM/yyyy";

        public void SetStartDate(string startDate)
        {
            StartDate = startDate;
        }

        public string GetStartDate()
        {
            return StartDate;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetImageLocation(string imageLocation)
        {
            ImageLocation = imageLocation;
        }

        public void SetLastDate(string date)
        {
            LastDate = date;
        }

        public string GetTitle()
        {
            return Title;
        }

        public string GetImageLocation()
        {
            return ImageLocation;
        }

        public string GetLastDate()
        {
            return Convert.ToDateTime(LastDate).ToString(FORMAT_DATE);
        }

        public void SetID(int id)
        {
            ID = id;
        }

        public int GetID()
        {
            return ID;
        }
    }
}
