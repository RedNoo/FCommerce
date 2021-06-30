using FCommerce.Model.Helper;
using System.Collections.Generic;

namespace FCommerce.Core.Connection
{
    public interface IConnection
    {
        IEnumerable<T> Query<T>(string query, object param = null);

        T Query<T>(int id);

        ListWithCount<T> QueryMulti<T>(string query, object param = null);

        void Execute(string query, object param = null);

        int? Execute<T>(T obj);
    }
}