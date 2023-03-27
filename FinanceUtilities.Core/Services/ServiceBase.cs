using FinanceUtilities.Data;

namespace FinanceUtilities.Core
{
    public abstract class ServiceBase
    {
        protected IFinanceContext _context;

        public ServiceBase(IFinanceContext context)
        {
            _context = context;
        }
    }
}
