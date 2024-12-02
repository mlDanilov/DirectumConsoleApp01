using CoreLib.Command;
using MeetingCoreLib.Command.Meeting;
using MeetingCoreLib.Command.Notification;
using MeetingCoreLib.CommandExecutor.Exception;
using MeetingCoreLib.Model;
using MeetingDomainLib.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MeetingCoreLib.CommandExecutor.Meeting
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    using Notification = MeetingDomainLib.Entities.Notification;

    /// <summary>
    /// Команда на создание уведомления
    /// </summary>
    public class CreateNotificationCommandExecutor
        : ACommandExecutor<CreateNotificationCommand>
    {
        
        public CreateNotificationCommandExecutor(MainModel model_)
            : base(model_)
        {
        }

        public override void Execute(CreateNotificationCommand cmd_)
        {
            if (_model.MeetingDisct.Count == 0)
                throw new CommandException<CreateNotificationCommand>("Не создано ни одной встречи. Не к чему привязывать уведомление", cmd_);

            if (!_model.MeetingDisct.ContainsKey(cmd_.MeetingId))
                throw new KeyNotFoundException($"Встреча с уникальным кодом '{cmd_.MeetingId}' не найдена. Не к чему привязывать уведомление");

            //У встречи не должно быть уведомления
            Notification notification = _model.NotificationDisct.Values.FirstOrDefault(ntfcn => ntfcn.Meeting.Id == cmd_.MeetingId);
            if (notification != null)
                throw new System.Exception($"У встречи c кодом {cmd_.MeetingId} уже есть уведомление. Новое создать невозможно");

            int newId = getNewNotificationId();
            var meeting = getMeeting(cmd_.MeetingId);
            

            notification = new Notification(newId, meeting) { Span = cmd_.Parameters.Span };
            _model.NotificationDisct.Add(notification.Id, notification);
        }

        /// <summary>
        /// Получить уникальный ключ для новой встречи
        /// </summary>
        /// <returns></returns>
        private int getNewNotificationId()
        {
            if (_model.NotificationDisct.Count == 0)
                return 1;
            else
                return _model.NotificationDisct.Select(m => m.Value.Id).Max() + 1;
        }

        private Meeting getMeeting(int meetingId_)
        {
            return _model.MeetingDisct[meetingId_];
        }
    }



}
