using FCommerce.Core.Connection;

namespace FCommerce.Core.Command
{
    public interface ICommand
    {
        int? Execute(IConnection connection);
    }
}
