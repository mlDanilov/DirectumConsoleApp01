using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingDomainLib.Entities
{
    /// <summary>
    /// Уведомление
    /// </summary>
    public class Notification : INotification
    {
        public Notification(int Id_, Meeting meeting_)
        { 
            Id = Id_;
            Meeting = meeting_;
        }
        /// <summary>
        /// Уникальный код
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Период уведомления до начала встречи
        /// </summary>
        public TimeSpan Span { get; set; }
        /// <summary>
        /// Был ли уведомлён пользователь
        /// </summary>
        public bool IsNotificated { get; set; } = false;
      
        /// <summary>
        /// Встреча
        /// </summary>
        public Meeting Meeting { get; set; }
    }
    
}
