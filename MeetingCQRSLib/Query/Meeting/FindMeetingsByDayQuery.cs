using CoreLib.Query;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.Query.Meeting
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    /// <summary>
    /// Запрос на получение встреч за выбранный день
    /// </summary>
    public class FindMeetingsByDayQuery
        : IQuery<List<Meeting>>
    {
        public FindMeetingsByDayQuery(DateTime day_) { 
            Day = day_;
        }

        public DateTime Day { get; init; }

    }
}
