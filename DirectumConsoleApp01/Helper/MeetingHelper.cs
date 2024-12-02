using MeetingCoreLib;
using MeetingCoreLib.Command.Meeting;
using MeetingCoreLib.Query.Meeting;
using MeetingDomainLib.Entities;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DirectumConsoleApp01.Helper
{
    /// <summary>
    /// Хелпер по встречам
    /// </summary>
    public static class MeetingHelper
    {
        /// <summary>
        /// Получить встречи за указанный день
        /// </summary>
        /// <param name="day_"></param>
        /// <returns></returns>
        public static List<Meeting> GetMeetingsByDay(DateTime day_)
        {
            var query = new FindMeetingsByDayQuery(day_);
            var meetings = QueryDispatcher.Execute<FindMeetingsByDayQuery, List<Meeting>>(query);
            return meetings;
        }
        /// <summary>
        /// Получить встречи по ключам
        /// </summary>
        /// <param name="day_"></param>
        /// <returns></returns>
        public static List<Meeting> GetMeetingsByIds(int[] meetingIds_)
        {
            var query = new FindMeetingsByIdsQuery(meetingIds_);
            var meetings = QueryDispatcher.Execute<FindMeetingsByIdsQuery, List<Meeting>>(query);
            return meetings;
        }
        /// <summary>
        /// Экспортировать встречи за указанный день в указанный файл
        /// </summary>
        /// <param name="fileName_"></param>
        /// <param name="day_"></param>
        public static void  ExportMeetingsToFileByDay(string fileName_, DateTime day_)
        {
            var query = new ExportToFileQuery(fileName_, day_);
            QueryDispatcher.Execute<ExportToFileQuery, int>(query);
        }

        /// <summary>
        /// Создать встречу 
        /// </summary>
        /// <param name="fileName_"></param>
        /// <param name="day_"></param>
        public static void CreateMeeting(DateTime from_, DateTime to_)
        {
            var cmd = new CreateMeetingCommand(
                new Meeting(-1, from_, to_)
                , isAchive_: (from_ < DateTime.Now) );
            CommandDispatcher.Execute(cmd);
        }

        /// <summary>
        /// Обновить встречу 
        /// </summary>
        /// <param name="id_">Уникальный ключ встречи</param>
        /// <param name="from_"></param>
        /// <param name="to_"></param>
        public static void UpdateMeeting(int id_, DateTime from_, DateTime to_)
        {
            var cmd = new UpdateMeetingCommand(id_, new Meeting(id_, from_, to_));
            CommandDispatcher.Execute(cmd);
        }

        /// <summary>
        /// Удалить встречу
        /// </summary>
        /// <param name="meetingId_"></param>
        public static void DeleteMeeting(int meetingId_)
        {
            var cmd  = new DeleteMeetingCommand(meetingId_);
            CommandDispatcher.Execute(cmd); 
        }

        /// <summary>
        /// Вывести на экран встречу(и уведомления, если есть)
        /// </summary>
        /// <param name="meeting_"></param>
        public static void PrintMeeting(Meeting meeting_, Notification notification_)
        {
            var query = new PrintMeetingQuery(meeting_) { Notification = notification_ };
            QueryDispatcher.Execute<PrintMeetingQuery, int>(query);
        }

        /// <summary>
        /// Вывести на экран встречи(и уведомления при наличии)
        /// </summary>
        /// <param name="meetingList_"></param>
        public static void PrintMeetingList(List<Meeting> meetingList_)
        {
            foreach (var meeting in meetingList_)
            { 
                var notification = NotificationHelper.GetNotificationByMeetingId(meeting.Id);
                PrintMeeting(meeting, notification);
            }
        }
        

        public static QueryDispatcher QueryDispatcher { get; set; }
        public static CommandDispatcher CommandDispatcher { get; set; }


    }
}
