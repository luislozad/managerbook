using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerBookFinal.Module.Helper
{
    public static class Time
    {
        public static int GetHourTimeUnix(long time)
        {
            string hour = DateTimeOffset
                            .FromUnixTimeSeconds(time)
                            .ToLocalTime()
                            .ToString("HH");

            if (int.TryParse(hour, out int result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}
