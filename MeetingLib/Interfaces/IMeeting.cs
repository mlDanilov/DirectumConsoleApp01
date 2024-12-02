using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingDomainLib.Interfaces
{
    public interface IMeeting
    {
        /// <summary>
        /// Уникальный ключ
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Начало встречи
        /// </summary>
        public DateTime From { get;  }
        /// <summary>
        /// Конец встречи
        /// </summary>
        public DateTime To { get; }

        /// <summary>
        /// Обновить параметры встречи
        /// </summary>
        /// <param name="params_"></param>
        public void Update(IMeeting params_);
    }
}
