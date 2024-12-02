using MeetingDomainLib.Exception;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingDomainLib.Entities
{
    /// <summary>
    /// Встреча
    /// </summary>
    public class Meeting : IMeeting
    {
        private DateTime _from;
        private DateTime _to;
        public Meeting(int id_, DateTime from_, DateTime to_)
        {
            checkFromTo(from_, to_);
            Id = id_;
            _from = from_;
            _to = to_;
        }

        /// <summary>
        /// Уникальный код
        /// </summary>
        public int Id { get; }
       
        /// <summary>
        /// Начало встречи
        /// </summary>
        public DateTime From { 
            get =>_from; 
        }
        /// <summary>
        /// Конец встречи
        /// </summary>
        public DateTime To {
            get => _to;
        }

        public void Update(IMeeting params_) {
            checkFromTo(params_.From, params_.To);
            _from = params_.From;
            _to = params_.To;   
        }

        private void checkFromTo(DateTime from_, DateTime to_) {
            if (from_ >= to_)
                throw new MeetingFromToException(from_, to_
                    , $"Начало встречи {from_.ToString("yyyy-MM-dd HH:mm:ss")} больше чем конец встречи {to_.ToString("yyyy-MM-dd HH:mm:ss")}");
        }
    }
}
