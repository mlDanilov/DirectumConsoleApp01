using MeetingCoreLib.Model;
using MeetingCoreLib.Query.Meeting;
using MeetingDomainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.QueryExecutor.Meeting
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    using Notification = MeetingDomainLib.Entities.Notification;
    /// <summary>
    /// Вывести на экран встречи(и уведомления, если есть)
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class PrintMeetingQueryExecutor
        : AQueryExecutor<PrintMeetingQuery, int>
    {
        public PrintMeetingQueryExecutor(MainModel model_):base(model_) { 
            
        } 
        public override int Execute(PrintMeetingQuery query_)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (query_.Notification != null)
                printMeeting(query_.Meeting, query_.Notification);
            else
                printMeeting(query_.Meeting);
            Console.ForegroundColor = ConsoleColor.White;
            return 1;
            
        }

        /// <summary>
        /// Вывести на экран встречу
        /// </summary>
        /// <param name="meeting_"></param>
        private void printMeeting(Meeting meeting_)
        {
            Console.WriteLine($"\r\nВстреча: {meeting_.Id}. Период: ({meeting_.From.ToCustomSTR()} - {meeting_.To.ToCustomSTR()})");
        }
        /// <summary>
        /// Вывести на экран встречу и уведомление
        /// </summary>
        /// <param name="meeting_"></param>
        private void printMeeting(Meeting meeting_, Notification notification_)
        {
            Console.WriteLine($"\r\nВстреча: {meeting_.Id}. Период: ({meeting_.From.ToCustomSTR()} - {meeting_.To.ToCustomSTR()}). Уведомление(Код: {notification_.Id}). Уведомить после {meeting_.From.AddTicks(-notification_.Span.Ticks).ToCustomSTR()} ");
            if (notification_.IsNotificated)
            {
              
                Console.Write($". Уведомление было отправлено");
              
            }
        }

     
    }
}
