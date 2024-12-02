using CoreLib.Command;
using MeetingCoreLib.Query.Meeting;
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
    /// Команда на создание напоминания
    /// </summary>
    public class CreateNotificationCommand : ANotificationCommand
    {
        public CreateNotificationCommand(
            INotification parameters_, int meetingId_)
        {
            MeetingId = meetingId_;
            Parameters = parameters_;
        }

        public int MeetingId { get; init; }
      
        public INotification Parameters { get; init; }
    }
}


