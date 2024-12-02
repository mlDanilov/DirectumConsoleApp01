using CoreLib.Query;
using MeetingCoreLib.Model;
using MeetingCoreLib.Query.Meeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.QueryExecutor.Meeting
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    /// <summary>
    /// Найти встречи за выбранный день
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public class FindMeetingsByDayQueryExecutor
        : AQueryExecutor<FindMeetingsByDayQuery, List<Meeting>>
    {
        public FindMeetingsByDayQueryExecutor(MainModel model_)
            : base(model_)
        {

        }
        public override List<Meeting> Execute(FindMeetingsByDayQuery query_)
        {
            var result = _model.MeetingDisct.Values.Where(
                mt => mt.From.Date == query_.Day.Date &&
                mt.To.Date == query_.Day.Date).ToList();

            return result;
        }
    }
}
