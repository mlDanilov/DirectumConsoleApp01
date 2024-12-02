using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Command
{
    /// <summary>
    /// Обработчик команды
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandExecutor<in TCommand> 
        where  TCommand : ICommand
    {
        void Execute(TCommand command_);
    }


    public interface ICommandException<TCommand>
         where TCommand : ICommand
    {
        TCommand Command { get; }
    }
}
