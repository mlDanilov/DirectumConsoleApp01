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

namespace MeetingCoreLib.CommandExecutor
{
    /// <summary>
    /// Команда на обновление встречи
    /// </summary>
    internal class UpdateMeetingCommandExecutor
         : ACommandExecutor<UpdateMeetingCommand>
    {
        public UpdateMeetingCommandExecutor(MainModel model_)
           : base(model_)
        {

        }

        public override void Execute(UpdateMeetingCommand cmd_)
        {
            if (cmd_.Parameters.From <= DateTime.Now)
                throw new CommandException<UpdateMeetingCommand>($"Дата начала встречи({cmd_.Parameters.From.ToCustomSTR()}) раньше текущего времени", cmd_);
            
            if (!_model.MeetingDisct.ContainsKey(cmd_.Id))
                throw new KeyNotFoundException($"Встреча с уникальным кодом {cmd_.Id} не найдена");

            if (_model.MeetingDisct.Count == 0)
                throw new CommandException<UpdateMeetingCommand>("Не создано ни одной встречи. Обновлять нечего", cmd_);
            

            //Проверка на пересечение с существующими встречами
            checkIntersection(cmd_);

            var meeting = _model.MeetingDisct[cmd_.Id];
            meeting.Update(cmd_.Parameters);
        }
        /// <summary>
        /// Проверка на пересечение с существующими встречами
        /// </summary>
        /// <param name="cmd_"></param>
        /// <exception cref="MeetingIntersectionExeception"></exception>
        private void checkIntersection(UpdateMeetingCommand cmd_)
        {
            foreach (var meeting in _model.MeetingDisct)
            {
                if (meeting.Value.Id == cmd_.Id)
                    continue;
                var intersectionFrom = meeting.Value.From > cmd_.Parameters.From ? meeting.Value.From : cmd_.Parameters.From; // начало пересечения
                var intersectionTo = meeting.Value.To < cmd_.Parameters.To ? meeting.Value.To : cmd_.Parameters.To; // конец пересечения

                if (intersectionFrom <= intersectionTo)
                    throw new MeetingIntersectionExeception(cmd_, meeting.Value, $"При попытке обновить встречу, обнаружено пересечение со встречей: Код {meeting.Key} Период: {meeting.Value.From.ToCustomSTR()} - {meeting.Value.To.ToCustomSTR()}");
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
