using CoreLib.Command;
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
    public class CreateMeetingCommand : AMeetingCommand
    {
        public CreateMeetingCommand(IMeeting parameters_, bool isAchive_ = false)
            : base(parameters_)
        {
            Parameters = parameters_;
            IsAchive = isAchive_;
        }
        /// <summary>
        /// Прошедшие встречи, которые нужно создать и не словить исключение
        /// </summary>
        public bool IsAchive { get; set; } = false;

    }
}


