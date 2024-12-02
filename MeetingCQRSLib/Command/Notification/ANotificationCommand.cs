using CoreLib.Command;
using MeetingDomainLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.Command.Notification
{
    public abstract class ANotificationCommand : ICommand
    {
        public ANotificationCommand()
        {
            //Parameters = parameters_;
        }

        public T GetValue<T>(string parameterName_)
        {
            return (T)_parameters[parameterName_];
        }

        public void SetValue<T>(string parameterName_, T value)
        {
            _parameters.Add(parameterName_, value);
        }

        public bool IsExistsParameter(string parameterName_) => _parameters.ContainsKey(parameterName_);

        private Dictionary<string, object> _parameters = new Dictionary<string, object>();
    }
}
