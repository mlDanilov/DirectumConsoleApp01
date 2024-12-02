using CoreLib.Command;
using MeetingDomainLib.Entities;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.Command.Notification
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    /// <summary>
    /// Удалить напоминание
    /// </summary>
    public class DeleteNotificationCommand : ICommand
    {
        public DeleteNotificationCommand(int key_)
        {
                NotificationId = key_;
        }

        public int NotificationId { get; init; } 
    }
}
