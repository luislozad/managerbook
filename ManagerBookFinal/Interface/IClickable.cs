using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Interface
{
    public interface IClickable<T> where T: IDataRaw
    {
        void OnActionClick(Action<T> handleAction);
        void SetClickeable(bool value);
    }
}
