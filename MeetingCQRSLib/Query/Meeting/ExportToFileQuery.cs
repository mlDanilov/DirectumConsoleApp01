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
    /// Экспортировать встречи за указанны день в указанный файл
    /// </summary>
    public class ExportToFileQuery
        : IQuery<int>
    {
        public ExportToFileQuery(string fullfileName_, DateTime day_) { 
            FullFileName = fullfileName_;
            Day = day_;
        }

        public string FullFileName { get; init; }

        public DateTime Day { get; init; }

    }
}
