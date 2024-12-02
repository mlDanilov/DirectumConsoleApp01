using MeetingDomainLib.Entities;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.Model
{
    /// <summary>
    /// Модель с сущностями
    /// </summary>
    public class MainModel
    {
        /// <summary>
        /// Встречи
        /// </summary>
        public Dictionary<int,Meeting> MeetingDisct { get; init; } = new Dictionary<int, Meeting>();

        /// <summary>
        /// Напоминания
        /// </summary>
        public Dictionary<int, Notification> NotificationDisct { get; init; } = new Dictionary<int, Notification>();


    }
}
