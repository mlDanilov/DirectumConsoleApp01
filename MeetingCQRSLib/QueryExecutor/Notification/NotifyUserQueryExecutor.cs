using CoreLib.Query;
using MeetingCoreLib.Model;
using MeetingCoreLib.Query.Meeting;
using MeetingCoreLib.Query.Notification;
using MeetingDomainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.QueryExecutor.Notification
{
    /// <summary>
    /// Исполнитель запроса "Уведомить пользователя о встречах"
    /// </summary>
    public class NotifyUserQueryExecutor
        : AQueryExecutor<NotifyUserQuery, int>
    {

        public NotifyUserQueryExecutor(MainModel model_) 
            : base(model_)
        { 
        
        }

        public override int Execute(NotifyUserQuery query_)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            bool notify= false;
            var sb = new StringBuilder("\r\nУведомляем!!!\r\n");

            foreach (var notification in 
                _model.NotificationDisct.Values.Where(nt => nt.IsNotificated == false))
            {
                
                var meeting = notification.Meeting;
                if (
                    DateTime.Now < meeting.From &&
                    DateTime.Now >= meeting.From.AddTicks(-notification.Span.Ticks))
                {
                    notify = true;
                    notification.IsNotificated = true;
                    sb.AppendLine($"Скоро будет встреча: Код {notification.Id}, период({meeting.From.ToCustomSTR()} - {meeting.To.ToCustomSTR()}) ");
                }
            }

            if (notify) { 
                Console.WriteLine(sb.ToString());
            }
            Console.ForegroundColor = ConsoleColor.White;
            return 1;
        }
    }
}
