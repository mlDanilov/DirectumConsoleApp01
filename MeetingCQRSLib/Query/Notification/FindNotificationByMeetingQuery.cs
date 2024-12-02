using CoreLib.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.Query.Notification
{
    using Notification = MeetingDomainLib.Entities.Notification;
    /// <summary>
    /// Найти уведомления(если есть) по коду встречи
    /// </summary>
    public class FindNotificationByMeetingQuery : IQuery<Notification>
    {
        public FindNotificationByMeetingQuery(int meetingId_)
        {
            MeetingId = meetingId_;
        }

        /// <summary>
        /// Уникальный код встречи
        /// </summary>
        public int MeetingId { get; set; }
    }
}
