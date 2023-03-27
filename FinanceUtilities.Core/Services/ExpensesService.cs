using System.Collections.Generic;
using System.Linq;
using FinanceUtilities.Core.Model;
using FinanceUtilities.Core.Settings;
using FinanceUtilities.Domain;

namespace FinanceUtilities.Core
{
    public class ExpensesService : IExpensesService
    {
        readonly ISettings _settings;

        public ExpensesService(ISettings settings)
        {
            _settings = settings;
        }
        public List<LoanPublicExpenseDto> CalculateExpenses(LoanProduct loan, decimal loanAmount, int years, string currency)
        {
            var relevantExpenses = RelevantExpenses(loan.LoanProductExpenses, currency, loanAmount, years);
            List<LoanPublicExpenseDto> result = new List<LoanPublicExpenseDto>();

            foreach (var expense in relevantExpenses)
            {
                result.Add(new LoanPublicExpenseDto
                    {
                        ExpenseType = expense.ExpenseType.Name,
                        Amount = CalculateExpense(expense, loanAmount, years, currency)
                    });
            }

            return result;
        }

        private List<LoanProductExpenseType> RelevantExpenses(List<LoanProductExpenseType> expenses, string currency, decimal loanAmount, int years)
        {
            return expenses.Where(e =>
            (((e.CurrencyCode == "MKD" ? e.LoanAmountFrom / _settings.EurExchangeRate : e.LoanAmountFrom) <= loanAmount 
            && loanAmount <= (e.CurrencyCode == "MKD" ? e.LoanAmountTo / _settings.EurExchangeRate : e.LoanAmountTo))
                || (e.LoanAmountFrom == 0 && e.LoanAmountTo == 0))
            && ((e.DurationFrom <= years * 12 && years * 12 <= e.DurationTo)
                || (e.DurationFrom == 0 && e.DurationTo == 0))
            ).ToList();
        }

        private decimal CalculateExpense(LoanProductExpenseType expense, decimal loanAmount, int years, string currency)
        {
            decimal result = 0;
            int recurringRate = CalculateReccuringRate(expense.RecurmentType, years);

            if (expense.Percentage > 0)
            {
                result = loanAmount * (expense.Percentage / 100) * recurringRate;
            }
            else if (expense.Amount > 0)
            {
                if (currency != "MKD")
                {
                    result = (expense.Amount / _settings.EurExchangeRate) * recurringRate;
                }
                else
                {
                    result = (expense.Amount / _settings.EurExchangeRate) * recurringRate;
                }
            }

            if(result < expense.Minimum)
            {
                result = expense.Minimum / _settings.EurExchangeRate;
            }
            else if(result > expense.Maximum && expense.Maximum > 0)
            {
                result = expense.Maximum / _settings.EurExchangeRate;
            }

            return result;
        }

        private int CalculateReccuringRate(RecurringType recurringType, int years)
        {
            int rate = 1;
            if (recurringType == RecurringType.Yearly)
            {
                rate = years;
            }
            else if (recurringType == RecurringType.Monthly)
            {
                rate = 12 * years;
            }
            return rate;
        }
    }
}