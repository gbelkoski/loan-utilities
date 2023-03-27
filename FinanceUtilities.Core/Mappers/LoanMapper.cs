using FinanceUtilities.Core.Model;
using FinanceUtilities.Domain;

namespace FinanceUtilities.Core.Mappers
{
    public static class LoanMapper
    {
        public static LoanDto ToDto(LoanProduct loan)
        {
            return new LoanDto()
            {
                Name = loan.Name,
                BankName = loan.Bank.Name,
                LoanType = loan.LoanType.Name,
                NewMarkupDate = loan.NewMarkupDate
            };
        }
    }
}
