using CoreLib.Command;
using MeetingCoreLib.Model;
using MeetingDomainLib.Entities;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.Command.Notification
{
    /// <summary>
    /// Команда на создание встречи
    /// </summary>
    public class UpdateNotificationCommand : ANotificationCommand
    {
        public UpdateNotificationCommand(int notificationId_)
            : base()
        {
            NotificationId = notificationId_;
        }

        public int NotificationId { get; init; }

    }
}


