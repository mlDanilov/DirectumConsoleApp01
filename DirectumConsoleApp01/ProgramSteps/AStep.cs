using DirectumConsoleApp01.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectumConsoleApp01.ProgramSteps
{
    public abstract class AStep
    {
        protected AStep() { 
        }

        public abstract void Execute();

        protected abstract void repeat();

        /// <summary>
        /// Введенная строка в консоли
        /// </summary>
        protected string _cmd = "";

        /// <summary>
        /// Уведомить о наступающих встречах
        /// </summary>
        protected void notify() => NotificationHelper.NotifyUser();

        protected void writeException(Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            
            Console.WriteLine(ex.Message.ToString());
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            repeat();
        }

        protected void writeSuccess(string message_)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;

            Console.WriteLine(message_);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
