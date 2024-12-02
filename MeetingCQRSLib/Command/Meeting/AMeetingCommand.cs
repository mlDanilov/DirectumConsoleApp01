using CoreLib.Command;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.Command.Meeting
{
    public abstract class AMeetingCommand : ICommand
    {

        public IMeeting Parameters { get; init; }

        public AMeetingCommand(
           IMeeting parameters_
            )
        {
            Parameters = parameters_;
        }
    }
}
