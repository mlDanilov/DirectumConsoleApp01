using MeetingCoreLib.Command.Meeting;
using MeetingCoreLib.Command.Notification;
using MeetingCoreLib.CommandExecutor.Exception;
using MeetingCoreLib.Model;
using MeetingDomainLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.CommandExecutor.Meeting
{
    /// <summary>
    /// Команда на обновление уведомления
    /// </summary>
    internal class DeleteNotificationCommandExecutor
         : ACommandExecutor<DeleteNotificationCommand>
    {
        public DeleteNotificationCommandExecutor(MainModel model_)
           : base(model_)
        {
        }

        public override void Execute(DeleteNotificationCommand cmd_)
        {
            if (!_model.NotificationDisct.ContainsKey(cmd_.NotificationId))
                throw new KeyNotFoundException($"Встреча с уникальным кодом '{cmd_.NotificationId}' не найдена");

            _model.NotificationDisct.Remove(cmd_.NotificationId);

        }
    }
}
