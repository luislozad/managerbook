using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Interface
{
    public interface IUpdateState<T, D>
    where
        T: IData<D>, IComponentUI
    {
        void OnActionEdit(Action<T> handleEdit);
    }
}
