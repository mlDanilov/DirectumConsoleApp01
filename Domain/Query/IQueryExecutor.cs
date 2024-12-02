using CoreLib.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLib.Query
{
    /// <summary>
    ///  Интерфейс обработчик запроса
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResult">Тип возвращаемого результата</typeparam>
    public interface IQueryExecutor<in TQuery, out TResult>
        where TQuery : IQuery<TResult>
    {
        TResult Execute(TQuery query_);
    }
}
