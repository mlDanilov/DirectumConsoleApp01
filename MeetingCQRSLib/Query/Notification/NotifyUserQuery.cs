using CoreLib.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.Query.Notification
{
    /// <summary>
    /// Запрос на уведомление пользователя о наступающих событиях
    /// </summary>
    public class NotifyUserQuery : IQuery<int>
    {
        public NotifyUserQuery() { 
        }
    }
}
