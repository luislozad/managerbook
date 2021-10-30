using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Interface
{
    public interface IDeleteState<T, D>
    where
        T : IData<D>, IDataRaw, IObjectID
    {
        void OnActionDelete(Action<T> handleDelete);
    }
}
