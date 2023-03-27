using FinanceUtilities.Core.Model;
using FinanceUtilities.Core.Models;
using FinanceUtilities.Domain;
using System.Collections.Generic;
using System.Linq;

namespace FinanceUtilities.Core.Mappers
{
    public class LoanTotalsFactory : ILoanTotalsFactory
    {
        public LoanTotals CreateItem(LoanProduct loan, string installmentInfo, string currency, decimal totalInterest, decimal totalBaseAndInterest, decimal amount, List<LoanPublicExpenseDto> expenses)
        {
            var totalExpenses = expenses.Sum(e => e.Amount);
            return new LoanTotals()
            {
                Id = loan.Id,
                InstallmentInfo = installmentInfo,
                MinimumAmount = loan.MinimumAmount.ToString("N2"),
                MaximumAmount = loan.MaximumAmount.ToString("N2"),
                MinimumDuration = loan.MinDuration.ToString(),
                MaximumDuration = loan.MaxDuration.ToString(),
                ParticipationPercentage = loan.ParticipationPercentage.ToString("N2"),
                CurrencyCode = currency,
                TotalInterest = totalInterest.ToString("N0"),
                TotalAmount = totalBaseAndInterest + totalExpenses,
                LoanAmount = amount.ToString("N0"),
                BankName = loan.Bank?.Name,
                BankWebsite = loan.Bank?.Website,
                AskQuoteEnabled = loan.Bank.AskQuoteEnabled,
                LoanLink = loan.Link,
                BankLogo = $"{AppSettings.ImageBaseUri}banklogos/{loan.Bank?.LogoImageName}",
                BankSmallLogo = $"{AppSettings.ImageBaseUri}banklogos/{loan.Bank?.LogoImageName.Replace(".", "73.")}",
                LoanName = loan.Name,
                LoanExpenses = expenses,
                TotalExpenses = totalExpenses.ToString("N0")
            };
        }
    }
}
