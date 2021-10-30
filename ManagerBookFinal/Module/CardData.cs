using ManagerBookFinal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Module
{
    public class CardData: IObjectID, IDataRaw
    {
        private int ID = -1;
        private int MaxMetaData = 8;
        private string Title, ImageLocation;
        private string[] MetaDataTitle, MetaDataValue;

        private IObjectID DataRaw;

        public string GeTitle()
        {
            return Title;
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public string GetImageLocation()
        {
            return ImageLocation;
        }

        public void SetImageLocation(string imageLocation)
        {
            ImageLocation = imageLocation;
        }
        public string[] GetMetaDataTitle()
        {
            return MetaDataTitle;
        }

        public string[] GetMetaDataValue()
        {
            return MetaDataValue;
        }
        public void SetMetaDataTitle(string[] titles)
        {

            string[] newTitles = NewMetaData(titles.Length);

            for (int i = 0; i < newTitles.Length; i++)
            {
                newTitles[i] = titles[i];
            }

            MetaDataTitle = newTitles;
        }

        public void SetMaxMetaData(int max)
        {
            MaxMetaData = max;
        }

        public int GetMaxMetaData()
        {
            return MaxMetaData;
        }

        public void SetMetaDataValue(string[] values)
        {
            string[] newValues = NewMetaData(values.Length);

            for (int i = 0; i < newValues.Length; i++)
            {
                newValues[i] = values[i];
            }

            MetaDataValue = newValues;
        }

        private string[] NewMetaData(int size)
        {
            int max = Math.Min(MaxMetaData, size);

            return new string[max];
        }

        public void SetID(int id)
        {
            ID = id;
        }

        public int GetID()
        {
            return ID;
        }

        public void SetDataRaw<D>(D dataRaw) where D : IObjectID
        {
            DataRaw = dataRaw;
        }

        public D GetDataRaw<D>() where D : IObjectID
        {
            return (D)DataRaw;
        }
    }
}
