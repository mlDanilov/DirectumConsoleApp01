using CoreLib.Command;
using CoreLib.Query;
using MeetingCoreLib.Model;
using MeetingCoreLib.Query.Meeting;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.QueryExecutor.Meeting
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    /// <summary>
    /// Найти встречи по уникальным ключам
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class FindMeetingsByIdsQueryExecutor
    : AQueryExecutor<FindMeetingsByIdsQuery, List<Meeting>>
    {
        public FindMeetingsByIdsQueryExecutor(MainModel model_) 
            : base(model_)
        {


        }

        public override List<Meeting> Execute(FindMeetingsByIdsQuery query_)
        {
           List<Meeting> result = new List<Meeting>();
            foreach(var key in query_.Keys) 
                if (_model.MeetingDisct.ContainsKey(key))
                    result.Add(_model.MeetingDisct[key]);

            return result;
        }
    }
}

