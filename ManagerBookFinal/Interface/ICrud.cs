using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Interface
{
    public interface ICrud<T>
    {
        T Create(T model);
        List<T> Read();
        List<T> Read(int limit);
        List<T> Read(Range range);
        void Update(T currentModel, T newModel);
        void Delete(T model);
    }
}
