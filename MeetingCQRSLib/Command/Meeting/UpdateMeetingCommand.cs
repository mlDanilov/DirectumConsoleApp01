using CoreLib.Command;
using MeetingCoreLib.Model;
using MeetingDomainLib.Entities;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.Command.Meeting
{
    /// <summary>
    /// Команда на создание встречи
    /// </summary>
    public class UpdateMeetingCommand : AMeetingCommand
    {
        public UpdateMeetingCommand(int id_, IMeeting params_)
            : base(params_)
        {
            Id = id_;
            Parameters = params_;
        }

        public int Id { get; init; }

    }
}


