using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingDomainLib.Exception
{
    /// <summary>
    /// Исключение: From > To 
    /// </summary>
    public class MeetingFromToException : System.Exception
    {
        public MeetingFromToException(
            DateTime from_
            , DateTime to_) : base()
        { 
            From = from_;
            To = to_;
        }

        public MeetingFromToException(
            DateTime from_
            , DateTime to_
            , string message_
            ) : base(message_)
        {
            From = from_;
            To = to_;
        }

        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}

