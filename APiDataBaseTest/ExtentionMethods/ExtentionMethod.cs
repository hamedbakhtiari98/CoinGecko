using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APiDataBaseTes
{
    public static class ExtentionMethod
    {
        public static string GetDate(this long unixTimeStamp)
        {
            var time = DateTimeOffset.FromUnixTimeMilliseconds(unixTimeStamp).DateTime;
            return $"{time.Day}-{time.Month}-{time.Year}";
        }
    }
}
