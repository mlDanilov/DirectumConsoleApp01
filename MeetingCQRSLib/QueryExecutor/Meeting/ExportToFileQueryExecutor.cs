using MeetingCoreLib.Model;
using MeetingCoreLib.Query.Meeting;
using MeetingDomainLib;
using MeetingDomainLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.QueryExecutor.Meeting
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    /// <summary>
    /// Экспортировать встречи за указанны день в указанный файл
    /// </summary>
    internal class ExportToFileQueryExecutor
        : AQueryExecutor<ExportToFileQuery, int>
    {
        public ExportToFileQueryExecutor(MainModel model_)
            : base(model_)
        {
            
        }
        public override int Execute(ExportToFileQuery query_)
        {
            var achiveMeetingList = _model.MeetingDisct.Values.Where(m => m.From < DateTime.Now && m.To.Date == query_.Day.Date).ToList();
            var actualMeetingList = _model.MeetingDisct.Values.Where(m => m.From > DateTime.Now && m.To.Date == query_.Day.Date).ToList();

            using (StreamWriter outputFile = new StreamWriter(query_.FullFileName, false))
            {
                outputFile.WriteLine("Прошедшие встречи");
                outputFile.WriteLine("Id\t\tFrom\t\t\tTo");
                foreach (var meeting in achiveMeetingList)
                {
                    outputFile.WriteLine($"{meeting.Id}\t\t{meeting.From.ToCustomSTR()}\t{meeting.To.ToCustomSTR()}");
                }

                outputFile.WriteLine("Предстоящие встречи");
                outputFile.WriteLine("Id\t\tFrom\t\t\tTo");
                foreach (var meeting in actualMeetingList)
                {
                    outputFile.WriteLine($"{meeting.Id}\t\t{meeting.From.ToCustomSTR()}\t{meeting.To.ToCustomSTR()}");
                }
            }


            return 1;
        }
    }
}
