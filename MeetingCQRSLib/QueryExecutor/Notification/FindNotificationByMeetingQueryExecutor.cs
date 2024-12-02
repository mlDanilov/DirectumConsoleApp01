using MeetingCoreLib.Model;
using MeetingCoreLib.Query.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.QueryExecutor.Notification
{
    using Notification = MeetingDomainLib.Entities.Notification;

    /// <summary>
    /// Исполнитель запроса "Получить уведомление по коду встречи"
    /// </summary>
    public class FindNotificationByMeetingQueryExecutor
         : AQueryExecutor<FindNotificationByMeetingQuery, Notification>
    {
        public FindNotificationByMeetingQueryExecutor(MainModel model_)
           : base(model_)
        {

        }
        public override Notification Execute(FindNotificationByMeetingQuery query_)
            => _model.NotificationDisct.Values.FirstOrDefault(ntfn => ntfn.Meeting.Id == query_.MeetingId);
    }
}
