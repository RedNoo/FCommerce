using FCommerce.Core.Context;

namespace FCommerce.Core.Service
{
    public class ServiceBase
    {
        protected readonly IContext _context;

        public ServiceBase(IContext context)
        {
            _context = context;
        }
    }
}
