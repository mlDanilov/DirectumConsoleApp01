using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingDomainLib
{
    public static class Helper
    {
        public static string ToCustomSTR(this DateTime datetime_)
        {
            return datetime_.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
