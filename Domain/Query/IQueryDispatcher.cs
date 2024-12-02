using CoreLib.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Query
{
    /// <summary>
    /// Централизованный обработчик запросов
    /// </summary>
    public interface IQueryDispatcher
    {

        TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
        //TResult Execute<TResult>(IQuery<TResult> query) ;

    }


}
