using CoreLib.Command;
using MeetingCoreLib.Command;
using MeetingCoreLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.CommandExecutor
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    using Notification = MeetingDomainLib.Entities.Meeting;

    /// <summary>
    /// Базовый класс для исполнителей команд
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public abstract class ACommandExecutor<TCommand>
        : ICommandExecutor<TCommand>
        where TCommand : ICommand
    {
        public ACommandExecutor(MainModel model_)
        {
            _model = model_;
        }

        protected readonly MainModel _model;
        
        public abstract void Execute(TCommand command_);
       
    }
}
