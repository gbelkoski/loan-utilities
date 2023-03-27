using System.Collections.Generic;

namespace FinanceUtilities.Core.Model
{
    public class LoanPublicDetailsDto
    {
        public string Name { get; set; }
        public string BankName { get; set; }
        public string BankWebsite { get; set; }
        public string BankSmallLogo { get; set; }
        public string LoanType { get; set; }
        public string CurrencyCode { get; set; }
        public string AmountFrom { get; set; }
        public string AmountTo { get; set; }
        public decimal ParticipationPercentage { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }

        //loan expenses
        public string TotalDirectExpenses { get; set; }
        public string TotalExpenses { get; set; }

        public string LoanAmount { get; set; }
        public string TotalInterest { get; set; }
        public string Total { get; set; }

        public List<LoanPublicExpenseDto> LoanExpenses { get; set; } = new List<LoanPublicExpenseDto>();
    }
}
