using FinanceUtilities.Domain;

namespace FinanceUtilities.Core.Model
{
    public class LoanExpense
    {
        public int Id { get; set; }
        public string ExpenseTypeId { get; set; }
        public bool Reccuring { get; set; }
        public RecurringType RecurmentType { get; set; }
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsBankClient { get; set; }
        public decimal LoanAmountFrom { get; set; }
        public decimal LoanAmountTo { get; set; }
        public int? DurationFrom { get; set; }
        public int? DurationTo { get; set; }
    }
}
