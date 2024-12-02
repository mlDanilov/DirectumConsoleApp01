using CoreLib.Command;
using MeetingCoreLib.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.CommandExecutor.Exception
{
    public class CommandException<TCommand> 
        : System.Exception, ICommandException<TCommand>
         where TCommand : ICommand
    {

        public CommandException(TCommand command_)
         : base()
        {
            Command = command_;
        }

        public CommandException(string message_, TCommand command_)
          : base(message_)
        {
            Command = command_;
        }
        public TCommand Command { get; init; }
    }
}
