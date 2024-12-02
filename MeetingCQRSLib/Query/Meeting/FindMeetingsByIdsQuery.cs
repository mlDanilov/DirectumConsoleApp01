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
    /// Запрос на получение встреч по уникальным ключам
    /// </summary>
    public class FindMeetingsByIdsQuery
        : IQuery<List<Meeting>>
    {
        public FindMeetingsByIdsQuery(int[] keys_) { 
            Keys = keys_;
        }

        public int[] Keys { get; init; }

    }
}
