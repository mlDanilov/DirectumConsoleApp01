using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Command
{
    /// <summary>
    /// Централизованный обработчик команд
    /// </summary>
    public interface ICommandDispatcher
    {

        void Execute<TCommand>(TCommand command_) 
            where TCommand : ICommand;

    }


}
