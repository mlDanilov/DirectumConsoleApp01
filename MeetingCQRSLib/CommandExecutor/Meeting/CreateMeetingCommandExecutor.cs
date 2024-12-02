using CoreLib.Command;
using MeetingCoreLib.Command.Meeting;
using MeetingCoreLib.CommandExecutor.Exception;
using MeetingCoreLib.Model;
using MeetingDomainLib;
using MeetingDomainLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MeetingCoreLib.CommandExecutor.Meeting
{
    using Meeting = MeetingDomainLib.Entities.Meeting;
    /// <summary>
    /// Команда на создание встречи
    /// </summary>
    public class CreateMeetingCommandExecutor
        : ACommandExecutor<CreateMeetingCommand>
    {
        
        public CreateMeetingCommandExecutor(MainModel model_)
            : base(model_)
        {
            
        }

        public override void Execute(CreateMeetingCommand command_)
        {
            try
            {
                if ((command_.Parameters.From <= DateTime.Now) && (!command_.IsAchive))
                    throw new CommandException<CreateMeetingCommand>(
                        $"Дата начала встречи({command_.Parameters.From.ToCustomSTR()}) раньше текущего времени", command_
                        );

                if (_model.MeetingDisct.Count == 0)
                {
                    var meeting = new Meeting(1, command_.Parameters.From, command_.Parameters.To);
                    _model.MeetingDisct.Add(meeting.Id, meeting);
                    return;
                }
                else
                {
                    //Проверка на пересечение с существующими встречами
                    checkIntersection(command_);
                    int newId = getNewMeetingId();
                    var meeting = new Meeting(newId, command_.Parameters.From, command_.Parameters.To);
                    _model.MeetingDisct.Add(newId, meeting);
                    return;
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Проверка на пересечение с существующими встречами
        /// </summary>
        /// <param name="cmd_"></param>
        /// <exception cref="MeetingIntersectionExeception"></exception>
        private void checkIntersection(CreateMeetingCommand cmd_)
        {
            foreach (var meeting in _model.MeetingDisct)
            {
                var intersectionFrom = meeting.Value.From > cmd_.Parameters.From ? meeting.Value.From : cmd_.Parameters.From; // начало пересечения
                var intersectionTo = meeting.Value.To < cmd_.Parameters.To ? meeting.Value.To : cmd_.Parameters.To; // конец пересечения

                if (intersectionFrom <= intersectionTo)
                    throw new MeetingIntersectionExeception(cmd_, meeting.Value, $"При попытке создать встречу, обнаружено пересечение со встречей: Код {meeting.Key} Период: {meeting.Value.From.ToCustomSTR()} - {meeting.Value.To.ToCustomSTR()}");
            }
        }

        /// <summary>
        /// Получить уникальный ключ для новой встречи
        /// </summary>
        /// <returns></returns>
        private int getNewMeetingId()
        {
            return _model.MeetingDisct.Select(m => m.Value.Id).Max() + 1;
        }
    }



}
