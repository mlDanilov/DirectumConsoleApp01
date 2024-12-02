using MeetingDomainLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingDomainLib.Interfaces
{
    /// <summary>
    /// Уведомление о встрече
    /// </summary>
    public interface INotification
    {
        /// <summary>
        /// Уникальный ключ
        /// </summary>
        int Id { get; }
        /// <summary>
        /// Период уведомления до начала встречи
        /// </summary>
        TimeSpan Span { get; set; } 
        /// <summary>
        /// Был ли уведомлён пользователь
        /// </summary>
        bool IsNotificated { get; set; }

        /// <summary>
        /// Встреча
        /// </summary>
        public Meeting Meeting { get; }

    }
}
