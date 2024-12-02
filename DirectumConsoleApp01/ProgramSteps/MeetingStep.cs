using DirectumConsoleApp01.Helper;
using DirectumConsoleApp01.UserCommand;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DirectumConsoleApp01.ProgramSteps
{
    /// <summary>
    /// Шаг "Встречи"
    /// </summary>
    public class MeetingStep : AStep
    {

        public override void Execute()
        {
            Console.Clear();
            notify();
            showInfo();
            menu();
            
        }

        private void menu()
        {

            _cmd = Console.ReadLine();

            //Вывести на экран встречи за указанный день
            if (_meetingDayRegex.IsMatch(_cmd) && DateTime.TryParse(_cmd.Substring(12, 10), out DateTime day))
            {

                var meetingList = MeetingHelper.GetMeetingsByDay(day);
                Console.Clear();
                MeetingHelper.PrintMeetingList(meetingList);
                notify();
                showInfo();
                menu();

            }
            //Вывести на экран встречи по кодам
            else if (_meetingIdRegex.IsMatch(_cmd))
            {
                var idSTR = _cmd.Substring(10, _cmd.Length - 10);
                int[] meetingIdArray = idSTR.Split(';').Select(n => Convert.ToInt32(n)).ToArray();

                var meetingList = MeetingHelper.GetMeetingsByIds(meetingIdArray);
                Console.Clear();
                MeetingHelper.PrintMeetingList(meetingList);
                notify();
                showInfo();
                menu();
            }
            //Экспортировать встречи в файл за выбранный день
            else if (_cmd.StartsWith("meeting_export "))
            {
                string[] array = _cmd.Split(" ");
                if (array.Length != 3)
                {
                    Console.Clear();
                    this.repeat();
                    return;
                }

                string dateSTR = array[1];
                string fileName = array[2];

                if (!_dayRegex.IsMatch(dateSTR) || (!DateTime.TryParse(dateSTR, out day)))
                {
                    Console.Clear();
                    this.repeat();
                    return;
                }


                if (!isValidFileName(fileName))
                {
                    Console.Clear();
                    this.repeat();
                    return;
                }

                MeetingHelper.ExportMeetingsToFileByDay(fileName, day);
                Console.Clear();
                writeSuccess("Файл успешно экспортирован");
                notify();
                showInfo();
                menu();
            }
            //Создать встречу
            else if (_createMeetingDateTimeRegex.IsMatch(_cmd))
            {
                string[] array = _cmd.Split(" ");
                var fromSTR = array[1] + " " + array[2];
                var toSTR = array[3] + " " + array[4];

                if (!DateTime.TryParse(fromSTR, out DateTime from) || !DateTime.TryParse(toSTR, out DateTime to))
                {
                    Console.Clear();
                    this.repeat();
                    return;
                }
                try
                {
                    MeetingHelper.CreateMeeting(from, to);
                    Console.Clear();
                    writeSuccess("Встреча создана успешно!");
                    notify();
                    showInfo();
                    menu();
                }
                catch (Exception ex)
                {
                    writeException(ex);
                }



            }
            //Обновить встречу
            else if (_updateMeetingDateTimeRegex.IsMatch(_cmd))
            {
                string[] array = _cmd.Split(" ");
                var fromSTR = array[2] + " " + array[3];
                var toSTR = array[4] + " " + array[5];

                if (!DateTime.TryParse(fromSTR, out DateTime from) || !DateTime.TryParse(toSTR, out DateTime to) || !int.TryParse(array[1], out int meetingId))
                {
                    Console.Clear();
                    this.repeat();
                    return;
                }
                try
                {
                    MeetingHelper.UpdateMeeting(meetingId, from, to);
                    Console.Clear();
                    writeSuccess($"Встреча(Код {meetingId}) успешно обновлена!");
                    notify();
                    showInfo();
                    menu();
                }
                catch (Exception ex)
                {
                    writeException(ex);
                }



            }
            //Удалить встречу
            else if (_deleteMeetingIdRegex.IsMatch(_cmd))
            {
                string[] array = _cmd.Split(" ");
                if (!int.TryParse(array[1], out int meetingId))
                {
                    Console.Clear();
                    this.repeat();
                    return;
                }
                try
                {
                    MeetingHelper.DeleteMeeting(meetingId);
                    Console.Clear();
                    writeSuccess($"Встреча(Код {meetingId}) успешно удалена!");
                    notify();
                    showInfo();
                    menu();
                }
                catch (Exception ex)
                {
                    writeException(ex);
                }
            }
            //Вернуться в главное меню
            else if (_cmd == "mainMenu")
            {
                new MainMenuStep().Execute();
            }
            else if (_cmd == "exit")
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                this.repeat();
            }
            
        }
        protected void showInfo()
        {
            int index = 1;
            Console.WriteLine("\r\nДоступны следующие действия:");
            Console.WriteLine($"{index++})Посмотреть встречи за указанный день: 'meeting_day yyyy-MM-dd' ");
            Console.WriteLine($"{index++})Посмотреть встречи по уникальным кодам: 'meeting_id 1;2;..N' ");
            Console.WriteLine($"{index++})Экспортировать встречи в файд: 'meeting_export yyyy-MM-dd filename.txt' ");
            Console.WriteLine();
            Console.WriteLine($"{index++})Создать встречу(From To): 'create yyyy-MM-dd HH:mm:ss yyyy-MM-dd HH:mm:ss' ");
            Console.WriteLine($"{index++})Изменить встречу(meetingId From To): 'update meetingId yyyy-MM-dd HH:mm:ss yyyy-MM-dd HH:mm:ss' ");
            Console.WriteLine($"{index++})Удалить встречу(meetingId): 'delete meetingId' ");
            Console.WriteLine();
            Console.WriteLine($"{index++})Вернуться в главное меню: 'mainMenu' ");
            Console.WriteLine($"{index++})Покинуть программу: 'exit' ");
        }

        protected override void repeat()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Команда '{_cmd}' недопустима");
            Console.ForegroundColor = ConsoleColor.White;
            notify();
            showInfo();
            menu();

        }


        private bool isValidFileName(string fileName_)
        {
            if (fileName_.Length < 5) return false;
            char[] invalidPathChars = Path.GetInvalidPathChars();
            foreach(char c in invalidPathChars)
            {
                if (fileName_.Contains(c))
                    return false;
            }
            if (!fileName_.EndsWith(".txt"))
                return false;
            return true;
        }

        private readonly Regex _dayRegex = new Regex(@"((\d+);)*(\d+)$");
        private readonly Regex _deleteMeetingIdRegex = new Regex(@"delete ((\d+);)*(\d+)$");
        private readonly Regex _meetingIdRegex = new Regex(@"meeting_id ((\d+);)*(\d+)$");
        private readonly Regex _meetingDayRegex = new Regex(@"meeting_day (\d{4})-(\d{2})-(\d{2})$");
        
        private readonly Regex _createMeetingDateTimeRegex = new Regex(@"create (\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2}) (\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2})$") ;
        private readonly Regex _updateMeetingDateTimeRegex = new Regex(@"update (\d+) (\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2}) (\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2}):(\d{2})$");

    }
}
