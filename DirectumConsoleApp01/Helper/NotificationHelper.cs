using MeetingCoreLib.Command.Meeting;
using MeetingCoreLib.Query.Meeting;
using MeetingCoreLib;
using MeetingDomainLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingCoreLib.Command.Notification;
using MeetingCoreLib.Query.Notification;
using MeetingCoreLib.QueryExecutor.Notification;

namespace DirectumConsoleApp01.Helper
{
    /// <summary>
    /// Хэлпер по уведомлениям
    /// </summary>
    public static class NotificationHelper
    {
        /// <summary>
        /// Создать уведомление 
        /// </summary>
        /// <param name="fileName_"></param>
        /// <param name="day_"></param>
        public static void CreateNotification(int meetingId_, TimeSpan timeSpan_)
        {
            var cmd = new CreateNotificationCommand(
                new Notification(-1, null) { Span = timeSpan_ }, meetingId_
                );
            CommandDispatcher.Execute(cmd);
        }

        /// <summary>
        /// Обновить уведомление
        /// </summary>
        /// <param name="notificationId_">Уникальный ключ встречи</param>
        /// <param name="from_"></param>
        /// <param name="to_"></param>
        public static void UpdateNotification(
                int notificationId_
            , bool isNotificated
            )
        {
            var cmd = new UpdateNotificationCommand(notificationId_);
            cmd.SetValue("IsNotificated", isNotificated);
            CommandDispatcher.Execute(cmd);
        }
        /// <summary>
        /// Обновить уведомление
        /// </summary>
        /// <param name="notificationId_">Уникальный ключ уведомления</param>
        /// <param name="from_"></param>
        /// <param name="to_"></param>
        public static void UpdateNotification(int notificationId_, TimeSpan timeSpan_)
        {
            var cmd = new UpdateNotificationCommand(notificationId_);
            cmd.SetValue("Span", timeSpan_);
            CommandDispatcher.Execute(cmd);
        }
        /// <summary>
        /// Обновить уведомление
        /// </summary>
        /// <param name="notificationId_"></param>
        /// <param name="newMeetingId_"></param>
        /// <exception cref="NullReferenceException"></exception>
        public static void UpdateNotification(int notificationId_, int newMeetingId_)
        {
            var meeting = MeetingHelper.GetMeetingsByIds([newMeetingId_]).FirstOrDefault();
            if (meeting == null)
                throw new NullReferenceException($"Не найдено встречи с уникальным кодом {newMeetingId_}");

            var cmd = new UpdateNotificationCommand(notificationId_);
            cmd.SetValue("Meeting", meeting);
            CommandDispatcher.Execute(cmd);
        }

        /// <summary>
        /// Удалить уведомление
        /// </summary>
        /// <param name="id_">Уникальный ключ уведомления</param>
        /// <param name="from_"></param>
        /// <param name="to_"></param>
        public static void DeleteNotification(int id_)
        {
            var cmd = new DeleteNotificationCommand(id_);
            CommandDispatcher.Execute(cmd);
        }

        /// <summary>
        /// Уведомить пользователя
        /// </summary>
        public static void NotifyUser()
        {
            var query = new NotifyUserQuery();
            QueryDispatcher.Execute<NotifyUserQuery, int>(query);
        }
        /// <summary>
        /// Получить уведомление по уникальному коду встречи
        /// </summary>
        /// <param name="meetingId_"></param>
        /// <returns></returns>
        public static Notification GetNotificationByMeetingId(int meetingId_)
        { 
            var query = new FindNotificationByMeetingQuery(meetingId_);
            var notification = QueryDispatcher.Execute<FindNotificationByMeetingQuery, Notification>(query);
            return notification;
        }

        public static QueryDispatcher QueryDispatcher { get; set; }
        public static CommandDispatcher CommandDispatcher { get; set; }
    }
}
