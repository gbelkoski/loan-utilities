using FinanceUtilities.Core.Model;
using FinanceUtilities.Core.Models;
using FinanceUtilities.Domain;
using System.Collections.Generic;

namespace FinanceUtilities.Core.Mappers
{
    public interface ILoanTotalsFactory
    {
        LoanTotals CreateItem(LoanProduct loan, string installmentInfo, string currency, decimal totalInterest, decimal total, decimal amount, List<LoanPublicExpenseDto> expenses);
    }
}