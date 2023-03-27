using System.Collections.Generic;

namespace FinanceUtilities.Core
{
    public interface ILoanCalculate
    {
        void CalculateLoan(List<InterestPeriod> interestPeriods, decimal maxAllowedInterestPercentage);
    }
}