using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Interface
{
    public interface IShowControl<T> where T: IObjectID
    {
        void ShowView(T obj);
    }
}
