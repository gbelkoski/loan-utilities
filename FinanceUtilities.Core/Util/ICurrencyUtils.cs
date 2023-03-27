namespace FinanceUtilities.Core
{
    public interface ICurrencyUtils
    {
        decimal ConvertToLcy(decimal amount, string currencyCode);
    }
}