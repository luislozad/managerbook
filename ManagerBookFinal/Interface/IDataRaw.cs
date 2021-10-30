using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Interface
{
    public interface IDataRaw: IObjectID
    {
        void SetDataRaw<D>(D dataRaw)
        where D: IObjectID;
        D GetDataRaw<D>()
        where D: IObjectID;
    }
}
