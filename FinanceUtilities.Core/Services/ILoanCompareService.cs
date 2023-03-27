using FinanceUtilities.Core.Models;
using System.Collections.Generic;

namespace FinanceUtilities.Core
{
    public interface ILoanCompareService
    {
        List<LoanTotals> CalculateLoanProductTotals(int years, decimal amount, bool willChangeBank, string currencyCode, string loanTypeId, int? bankId);

        List<AmortizationLineItem> CalculateLoanAmortPlan(int loanId, decimal amount, int years, string currencyCode, bool willChangeBank, int? bankId);
    }
}