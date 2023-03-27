using System.Linq;
using FinanceUtilities.Data;

namespace FinanceUtilities.Core
{
    public class CurrencyUtils : ServiceBase, ICurrencyUtils
    {
        public CurrencyUtils(IFinanceContext context) : base(context)
        {
        }

        public decimal ConvertToLcy(decimal amount, string currencyCode)
        {
            if (!string.IsNullOrEmpty(currencyCode) && currencyCode != "MKD")
            {
                var currency = _context.Currencies.FirstOrDefault(c => c.Code == currencyCode);
                if (currency != null)
                {
                    return amount * currency.ExchangeRate;
                }
            }
            return amount;
        }
    }
}