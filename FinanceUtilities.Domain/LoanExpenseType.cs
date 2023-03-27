namespace FinanceUtilities.Domain
{
    public enum RecurringType
    {
        None = 0,
        Yearly = 1,
        Monthly = 2,
    }
    public class LoanProductExpenseType
    {
        public int Id { get; set; }
        public int LoanProductId { get; set; }
        public string ExpenseTypeId { get; set; }
        public virtual LoanProduct LoanProduct { get; set; }
        public virtual ExpenseType ExpenseType { get; set; }

        //calculation
        public decimal Percentage { get; set; }
        public decimal Amount { get; set; }
        public bool Reccuring { get; set; }
        public RecurringType RecurmentType { get; set; }

        //constraint
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }

        //criteria
        public decimal LoanAmountFrom { get; set; }
        public decimal LoanAmountTo { get; set; }

        public bool IsBankClient { get; set; }
        public string CurrencyCode { get; set; }
        public virtual Currency Currency { get; set; }
        public int? DurationFrom { get; set; }
        public int? DurationTo { get; set; }
    }
}
