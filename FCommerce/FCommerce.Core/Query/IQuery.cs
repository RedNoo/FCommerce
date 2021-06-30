using FCommerce.Core.Connection;

namespace FCommerce.Core.Query
{
    public interface IQuery<out T>
    {
        T Execute(IConnection connection);

    }
}
