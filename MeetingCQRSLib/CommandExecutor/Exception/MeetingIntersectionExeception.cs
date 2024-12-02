using CoreLib.Command;
using MeetingCoreLib.Command.Meeting;
using MeetingDomainLib.Entities;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MeetingCoreLib.CommandExecutor.Exception
{
    /// <summary>
    /// Пересечение с существующей встречей
    /// </summary>
    public class MeetingIntersectionExeception :
        CommandException<AMeetingCommand>
        //: System.Exception, ICommandException<CreateMeetingCommand>
    {
        public MeetingIntersectionExeception(
            AMeetingCommand cmmd_,
            IMeeting meeting_
            ) : base(cmmd_)
        {
            Meeting = meeting_;
            Command = cmmd_;
        }
        public MeetingIntersectionExeception(
            AMeetingCommand cmmd_,
            IMeeting meeting_, string message_
            ) : base(message_, cmmd_)
        {
            Meeting  = meeting_;
            Command = cmmd_;
        }

        public IMeeting Meeting { get; init; }
      
    }
}
