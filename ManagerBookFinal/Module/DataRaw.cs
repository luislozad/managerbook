using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ManagerBookFinal.Interface;

namespace ManagerBookFinal.Module
{
    public class DataRaw : IDataRaw, IObjectID
    {
        private int ID = -1;
        private IObjectID DataRawCurrent = null;

        public DataRaw()
        {
        }

        public D GetDataRaw<D>() where D : IObjectID
        {
            return (D)DataRawCurrent;
        }

        public int GetID()
        {
            return ID;
        }

        public void SetDataRaw<D>(D dataRaw) where D : IObjectID
        {
            DataRawCurrent = dataRaw;
        }

        public void SetID(int id)
        {
            ID = id;
        }
    }
}
