using System.Collections.Generic;

namespace FinanceUtilities.Core.Model
{
    public class LoanDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public string LoanTypeId { get; set; }
        public string LoanType { get; set; }

        public string CurrencyCode { get; set; }
        public int MaxDuration { get; set; }
        public int MinDuration { get; set; }
        public decimal MaximumAmount { get; set; }
        public decimal MinimumAmount { get; set; }
        public decimal ParticipationPercentage { get; set; }

        public string Link { get; set; }

        public List<LoanInterestPeriod> InterestPeriods { get; set; } = new List<LoanInterestPeriod>();
        public List<LoanExpense> LoanExpenses { get; set; } = new List<LoanExpense>();
    }
}
