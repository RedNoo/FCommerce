using FCommerce.Core.UnitOfWork;
using FCommerce.Model.Helper;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace FCommerce.Core.Connection
{
    public class DapperConnection : IConnection
    {
        private readonly IUnitOfWork _context;

        public DapperConnection(string connectionString)
        {
            _context = new DapperUnitOfWork(connectionString);
        }

        public DapperConnection(DapperUnitOfWork context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> Query<T>(string query, object param = null)
        {
            return _context.Transaction(transaction =>
            {
                var result = _context.Connection.Query<T>(query, param, transaction);
                return result;
            });
        }

        public virtual T Query<T>(dynamic id)
        {
            return _context.Transaction(transaction =>
            {
                var result = _context.Connection.Get<T>(id, transaction,30);

                return result;
            });
        }


        public virtual ListWithCount<T> QueryMulti<T>(string query, object param = null)
        {
            int count = 0;
            List<T> result = null;

            return _context.Transaction(transaction =>
            {
                using (var multi = _context.Connection.QueryMultiple(query, param, transaction))
                {
                    count = multi.Read<int>().Single();
                    result = multi.Read<T>().ToList();
                }

                ListWithCount<T> multiList = new ListWithCount<T>(count, result);

                return multiList;


            });
        }

        public void Execute(string query, object param = null)
        {
            _context.Transaction(transaction => _context.Connection.Execute(query, param, transaction));
        }

        public int? Execute<T>(T obj)
        {
            return _context.Transaction(transaction => _context.Connection.Insert<T>(obj, transaction));
        }


    }

}
