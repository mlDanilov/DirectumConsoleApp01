using CoreLib.Command;
using CoreLib.Query;
using MeetingCoreLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingCoreLib.QueryExecutor
{
    /// <summary>
    /// Базовый класс для исполнителей запросов
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public abstract class AQueryExecutor<TQuery, TResult> : IQueryExecutor<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        public AQueryExecutor(MainModel model_)
        {
            _model = model_;
        }

        protected readonly MainModel _model;
        
        public abstract TResult Execute(TQuery query_);
       
    }
}
