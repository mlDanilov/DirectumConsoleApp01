using MeetingCoreLib.Command.Meeting;
using MeetingCoreLib.CommandExecutor.Exception;
using MeetingCoreLib.Model;
using MeetingDomainLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.CommandExecutor.Meeting
{
    /// <summary>
    /// Команда на удаление встречи
    /// </summary>
    internal class DeleteMeetingCommandExecutor
         : ACommandExecutor<DeleteMeetingCommand>
    {
        public DeleteMeetingCommandExecutor(MainModel model_)
           : base(model_)
        {
        }

        public override void Execute(DeleteMeetingCommand cmd_)
        {
            if (_model.MeetingDisct.Count == 0)
                throw new CommandException<DeleteMeetingCommand>("Не создано ни одной встречи. Удалять нечего", cmd_);

            if (!_model.MeetingDisct.ContainsKey(cmd_.Parameters.Id))
                throw new KeyNotFoundException($"Встреча с уникальным кодом {cmd_.Parameters.Id} не найдена");


            //Если у встречи есть уведомление, удаляем
            var notification  = _model.NotificationDisct.Values.FirstOrDefault(nt => nt.Meeting.Id == cmd_.Parameters.Id);
            if (notification != null) _model.NotificationDisct.Remove(notification.Id);
            //Удаляем встречу
            _model.MeetingDisct.Remove(cmd_.Parameters.Id);



        }
    }
}
