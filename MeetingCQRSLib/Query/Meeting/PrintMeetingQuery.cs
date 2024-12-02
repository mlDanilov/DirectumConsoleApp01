using CoreLib.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.Query.Meeting
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    using Notification = MeetingDomainLib.Entities.Notification;
    /// <summary>
    /// Вывести на экран встречи(и уведомления, если есть)
    /// </summary>
    public  class PrintMeetingQuery
        : IQuery<int>
    {
        public PrintMeetingQuery(Meeting meeting_)
        { 
            Meeting = meeting_;
        }
        public Meeting Meeting { get; init; }

        public Notification Notification { get; set; }

    }
}
