using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Interface.BehaviorC
{
    public interface IEventCard
    {
        void BuildEventClickCard(Action<IDataRaw> handleActionClick);
    }
}
