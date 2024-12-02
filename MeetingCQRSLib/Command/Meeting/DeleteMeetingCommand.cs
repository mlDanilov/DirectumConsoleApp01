using MeetingDomainLib.Entities;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.Command.Meeting
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    /// <summary>
    /// Удалить встречу
    /// </summary>
    public class DeleteMeetingCommand : AMeetingCommand
    {
        public DeleteMeetingCommand(IMeeting params_)
           : base(params_)
        {
        }

        public DeleteMeetingCommand(int key_)
           : base(new Meeting(key_, DateTime.MinValue, DateTime.MaxValue))
        {

        }
    }
}
