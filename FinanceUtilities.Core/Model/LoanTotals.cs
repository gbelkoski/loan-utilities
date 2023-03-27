using FinanceUtilities.Core.Model;
using System.Collections.Generic;

namespace FinanceUtilities.Core.Models
{
    public class LoanTotals
    {
        public int Id { get; set; }
        public string BankLogo { get; set; }
        public string BankSmallLogo { get; set; }
        public string BankName { get; set; }
        public string BankWebsite { get; set; }
        public bool AskQuoteEnabled { get; set; }
        public string LoanName { get; set; }
        public string LoanLink { get; set; }
        public string InterestPercentageInfo { get; set; }
        public string InstallmentInfo { get; set; }
        public string LoanAmount { get; set; }
        public string CurrencyCode { get; set; }
        public string TotalInterest { get; set; }
        public string Total { get { return TotalAmount.ToString("N2"); } }
        public decimal TotalAmount { get; set; }
        public string ParticipationPercentage { get; set; }

        public string MinimumAmount { get; set; }
        public string MaximumAmount { get; set; }

        public string MinimumDuration { get; set; }
        public string MaximumDuration { get; set; }

        //loan expenses
        public string TotalDirectExpenses { get; set; }
        public string TotalExpenses { get; set; }

        public List<LoanPublicExpenseDto> LoanExpenses { get; set; } = new List<LoanPublicExpenseDto>();
    }
}