using CoreLib.Command;
using MeetingCoreLib.Command.Meeting;
using MeetingCoreLib.Command.Notification;
using MeetingCoreLib.CommandExecutor.Exception;
using MeetingCoreLib.Model;
using MeetingDomainLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.CommandExecutor.Notification
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    using Notification = MeetingDomainLib.Entities.Notification;
    
    /// <summary>
    /// Команда на обновление уведомления
    /// </summary>
    internal class UpdateNotificationCommandExecutor
         : ACommandExecutor<UpdateNotificationCommand>
    {
        public UpdateNotificationCommandExecutor(MainModel model_)
           : base(model_)
        {
        }

        public override void Execute(UpdateNotificationCommand cmd_)
        {
            if (_model.NotificationDisct.Count == 0)
                throw new CommandException<UpdateNotificationCommand>("Не создано ни одного уведомления. Нечего обновлять", cmd_);

            if (!_model.NotificationDisct.ContainsKey(cmd_.NotificationId))
                throw new KeyNotFoundException($"Уведомление с уникальным кодом '{cmd_.NotificationId}' не найдена");

            
            var notification = getNotififacionById(cmd_.NotificationId);
            if (cmd_.IsExistsParameter("Span"))
                notification.Span = cmd_.GetValue<TimeSpan>("Span");
            if (cmd_.IsExistsParameter("Meeting"))
            {
                var meetingIn = cmd_.GetValue<Meeting>("Meeting");
                var notificationIn = getNotififacionOffMeeting(meetingIn);

                if (notificationIn != null)
                    throw new CommandException<UpdateNotificationCommand>(
                        $"У привязываемой встречи(код: {meetingIn.Id}) уже есть уведомление(код {notificationIn.Id}). Сначала удалите уведомление у встречи(Код: {meetingIn.Id}). Потом привязывайте встречу к уведомлению c кодом {cmd_.NotificationId}", cmd_);

                notification.Meeting = meetingIn;
            }
            if (cmd_.IsExistsParameter("IsNotificated"))
                notification.IsNotificated = cmd_.GetValue<bool>("IsNotificated");

        }


        /// <summary>
        /// Получить уникальный ключ для новой встречи
        /// </summary>
        /// <returns></returns>
        private Notification getNotififacionById(int notificationId_)
        {
            return _model.NotificationDisct[notificationId_];
        }

        /// <summary>
        /// Получить уникальный ключ для новой встречи
        /// </summary>
        /// <returns></returns>
        private Notification getNotififacionOffMeeting(Meeting meeting_)
        {
            return _model.NotificationDisct.Values.SingleOrDefault(ntfcn => ntfcn.Meeting != null && ntfcn.Meeting.Id == meeting_.Id);
        }
    }
}
