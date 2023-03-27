using System.Collections.Generic;
using FinanceUtilities.Core.Model;
using FinanceUtilities.Domain;

namespace FinanceUtilities.Core
{
    public interface IExpensesService
    {
        List<LoanPublicExpenseDto> CalculateExpenses(LoanProduct loan, decimal loanAmount, int years, string currency);

    }
}