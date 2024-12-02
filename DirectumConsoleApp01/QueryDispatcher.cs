using CoreLib.Command;
using CoreLib.Query;
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

    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly Container _resolver;

        public QueryDispatcher(Container resolver_)

        {
            _resolver = resolver_;
        }
        //TResult Execute<TResult>(IQuery<TResult> query);
       /* public TResult Execute<TResult>(IQuery<TResult> query_)
        {
            if (query_ == null)
                throw new ArgumentNullException("query_");

            var qExecutor = _resolver.GetInstance<IQueryExecutor<IQuery<TResult>, TResult>>();
            if (qExecutor == null)
                throw new QueryHandlerNotFoundException(typeof(IQuery<TResult>));

            return qExecutor.Execute(query_);

        }*/
        
        public TResult Execute<TQuery, TResult>(TQuery query_) 
            where TQuery : IQuery<TResult>
        {
            if (query_ == null) 
                throw new ArgumentNullException("query_");
            
            var qExecutor = _resolver.GetInstance<IQueryExecutor<TQuery, TResult>>();
            if (qExecutor == null)
                throw new QueryHandlerNotFoundException(typeof(TQuery));

            return qExecutor.Execute(query_);

        }

    }

    /// <summary>
    /// Не найден класс испонитель запроса
    /// </summary>
    public class QueryHandlerNotFoundException : Exception
    {

        public QueryHandlerNotFoundException(Type queryType_) : base()
        {
            QueryType = queryType_;
        }
        public QueryHandlerNotFoundException(Type queryType_, string message_) : base(message_)
        {
            QueryType = queryType_;
        }

        public Type QueryType { get; private set; }
    }


}
