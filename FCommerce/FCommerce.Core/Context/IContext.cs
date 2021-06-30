using FCommerce.Core.Command;
using FCommerce.Core.Query;

namespace FCommerce.Core.Context
{
    public interface IContext
    {
        T Query<T>(IQuery<T> query);

        int? Execute(ICommand command);
    }
}
