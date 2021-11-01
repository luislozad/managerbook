using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Module.Helper
{
    public static class Time
    {
        public static DateTimeOffset GetHourTimeUnix(long time)
        {
            return DateTimeOffset
                    .FromUnixTimeSeconds(time)
                    .ToLocalTime();
        }
    }
}
