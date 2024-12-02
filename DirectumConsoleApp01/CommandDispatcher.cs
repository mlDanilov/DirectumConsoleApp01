using CoreLib.Command;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICommand = CoreLib.Command.ICommand;

namespace MeetingCoreLib
{

    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly Container _resolver;

        public CommandDispatcher(Container resolver_)
        {
            _resolver = resolver_;
        }

        public void Execute<TCommand>(TCommand command_)
            where TCommand : ICommand
        {

            if (command_ == null)
                throw new ArgumentNullException("command_");

            var cmdExecutor = _resolver.GetInstance<ICommandExecutor<TCommand>>();

            if (cmdExecutor == null)
                throw new CommandHandlerNotFoundException(typeof(TCommand));

            cmdExecutor.Execute(command_);

        }

    }
    /// <summary>
    /// Не найдена команда исполнитель запроса
    /// </summary>
    public class CommandHandlerNotFoundException : Exception
    {

        public CommandHandlerNotFoundException(Type CommandType_) : base()
        {
            CommandType = CommandType_;
        }
        public CommandHandlerNotFoundException(Type commandType_, string message_) : base(message_)
        {
            CommandType = commandType_;
        }

        public Type CommandType { get; private set; }
    }


}
