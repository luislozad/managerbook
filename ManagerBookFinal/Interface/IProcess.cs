using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Interface
{
    public interface IProcess
    {
        void OnComplete(Action<int> handleComplete);
    }
}
