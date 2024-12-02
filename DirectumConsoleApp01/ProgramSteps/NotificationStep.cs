using DirectumConsoleApp01.Helper;
using DirectumConsoleApp01.UserCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DirectumConsoleApp01.ProgramSteps
{
    /// <summary>
    /// Шаг "Уведомления"
    /// </summary>
    public class NotificationStep : AStep
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

            //Создать уведомление
            if (_createNotificationRegex.IsMatch(_cmd))
            {
                string[] array = _cmd.Split(" ");

                try
                {
                    if (
                        !int.TryParse(array[1], out int meetingId) ||
                        !int.TryParse(array[2], out int day) ||
                        !int.TryParse(array[3], out int hour) ||
                        !int.TryParse(array[4], out int min) ||
                        !int.TryParse(array[5], out int sec)
                        )
                    {
                        Console.Clear();
                        this.repeat();
                        return;
                    }
                    if ((hour < 0 || hour > 24) || (min < 0 || min > 60) || (sec < 0 || sec> 60))
                    {
                        Console.Clear();
                        this.repeat();
                        return;
                    }
                    var timeSpan = new TimeSpan(day, hour, min, sec);
                    NotificationHelper.CreateNotification(meetingId, timeSpan);
                    Console.Clear();
                    writeSuccess("Уведомление успешно создано!");
                    notify();
                    showInfo();
                    menu();
                }
                catch (Exception ex)
                {
                    writeException(ex);
                }



            }
            //Изменить уведомление(notificationId дней часов минут секунд): 'update notificationId dd hh mm ss'");
            //Обновить уведомление
            else if (_updateNotification1Regex.IsMatch(_cmd))
            {
                string[] array = _cmd.Split(" ");
                var notifIdStr = array[1];
                var dayStr = array[2];
                var hourStr = array[3];
                var minStr = array[4];
                var secStr = array[5];

                if (!int.TryParse(dayStr, out int day) || 
                    !int.TryParse(hourStr, out int hour) ||
                    !int.TryParse(minStr, out int min) ||
                    !int.TryParse(secStr, out int sec) ||
                    !int.TryParse(notifIdStr, out int notificationId))
                {
                    Console.Clear();
                    this.repeat();
                    return;
                }
                if ((hour < 0 || hour > 24) || (min < 0 || min > 60) || (sec < 0 || sec > 60))
                {
                    Console.Clear();
                    this.repeat();
                    return;
                }
                try
                {
                    var timeSpan = new TimeSpan(day, hour, min, sec);
                    NotificationHelper.UpdateNotification(notificationId, timeSpan);
                    Console.Clear();
                    writeSuccess($"Уведомление (Код {notificationId}) успешно обновлено!");
                    notify();
                    showInfo();
                    menu();
                }
                catch (Exception ex)
                {
                    writeException(ex);
                }
            }
            //Обновить уведомление 1
            else if (_updateNotification1Regex.IsMatch(_cmd))
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
                    //NotificationHelper.UpdateNotification(meetingId, from, to);
                    Console.Clear();
                    Console.WriteLine($"Встреча(Код {meetingId}) успешно обновлена!");
                    notify();
                    showInfo();
                    menu();
                }
                catch (Exception ex)
                {
                    writeException(ex);
                }
            }
            //Обновить уведомление 2
            else if (_updateNotification2Regex.IsMatch(_cmd))
            {
                string[] array = _cmd.Split(" ");
                var nofitIdSTR = array[1];
                var meetingIdSTR = array[2];

                if (!int.TryParse(nofitIdSTR, out int nofiticationId) || 
                    !int.TryParse(meetingIdSTR, out int meetingId))

                {
                    Console.Clear();
                    this.repeat();
                    return;
                }
                try
                {
                    NotificationHelper.UpdateNotification(nofiticationId, meetingId);
                    Console.Clear();
                    writeSuccess($"Уведомление (Код {nofiticationId}) успешно обновлено!");
                    notify();
                    showInfo();
                    menu();
                }
                catch (Exception ex)
                {
                    writeException(ex);
                }
            }

            //Обновить уведомление3
            else if (_updateNotification3Regex.IsMatch(_cmd))
            {
                string[] array = _cmd.Split(" ");
                var notifIdSTR = array[1];
                var isNotifiedSTR = array[2];
                if (!int.TryParse(notifIdSTR, out int nofiticationId) ||
                    !bool.TryParse(isNotifiedSTR, out bool isNotified))
                {
                    Console.Clear();
                    this.repeat();
                    return;
                }
                try
                {
                    NotificationHelper.UpdateNotification(nofiticationId, isNotified);
                    Console.Clear();
                    writeSuccess($"Уведомление {nofiticationId} успешно обновлено!");
                    notify();
                    showInfo();
                    menu();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message.ToString());
                    this.repeat();
                }
            }
            else if (_deleteNotificationRegex.IsMatch(_cmd))
            {
                string[] array = _cmd.Split(" ");
                if (!int.TryParse(array[1], out int notificationId))
                {
                    Console.Clear();
                    this.repeat();
                    return;
                }
                try
                {
                    NotificationHelper.DeleteNotification(notificationId);
                    Console.Clear();
                    writeSuccess($"Уведомление(Код {notificationId}) успешно удалено!");
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
                this.repeat();
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
            Console.WriteLine("Доступны следующие действия:");
            Console.WriteLine($"{index++}) Создать уведомление(meetingId дней часов минут секунд): 'create meetingId dd hh mm ss' ");
            Console.WriteLine($"{index}.1)Изменить уведомление(notificationId дней часов минут секунд): 'update1 notificationId dd hh mm ss'");
            Console.WriteLine($"{index}.2)Изменить уведомление(notificationId meetingId): 'update2 notificationId meetingId' ");
            Console.WriteLine($"{index++}.3)Изменить уведомление(notificationId IsNotified): 'update3 notificationId isNotified(true/false)' ");
            Console.WriteLine($"{index++})Удалить уведомление(notificationId): 'delete notificationId' ");
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

        private readonly Regex _createNotificationRegex = new Regex(@"create (\d+) (\d+) (\d+) (\d+) (\d+)$");

        private readonly Regex _updateNotification1Regex = new Regex(@"update1 (\d+) (\d+) (\d+) (\d+) (\d+)$");
        private readonly Regex _updateNotification2Regex = new Regex(@"update2 (\d+) (\d+)$");
        private readonly Regex _updateNotification3Regex = new Regex(@"update3 (\d+) (true|false)$");

        private readonly Regex _deleteNotificationRegex = new Regex(@"delete (\d+)$");

    }
}
