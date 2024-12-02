using DirectumConsoleApp01.ProgramSteps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectumConsoleApp01.UserCommand
{
    /// <summary>
    /// Шаг "Главное меню"
    /// </summary>
    public class MainMenuStep : AStep
    {
        public MainMenuStep() : base() { 
        
        }   

        public override void Execute()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в программу управления встречами!");
            showInfo();
            menu();
            notify();
        }
        
        protected override void repeat()
        {
            Console.Clear();
            Console.WriteLine($"Команда '{_cmd}' недопустима");
            showInfo();
            menu();
            notify();
        }
        private void showInfo()
        {
            int index = 1;
            Console.WriteLine($"{index++})Работа со встречами: введите '1'") ;
            Console.WriteLine($"{index++})Работа с уведомлениями: введите '2'");
            Console.WriteLine($"{index++})Покинуть программу: введите 'exit'");
        }
        private void menu()
        {
            _cmd = Console.ReadLine();
            switch (_cmd)
            {
                case "1":
                    {
                        new MeetingStep().Execute();
                        return;
                    }
                case "2":
                    {
                        new NotificationStep().Execute();
                        return;
                    }
                case "exit":
                    {
                        break;
                    }
                default:
                    {
                        this.repeat();
                        break;
                    }

            }
        }
    }

}
