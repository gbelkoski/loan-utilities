namespace FinanceUtilities.Domain
{
    public enum IRType
    {
        Fixed = 0,
        Variable = 1
    }

    public class InterestPeriod
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        //euribor, skibor
        public string ReferenceInterestId { get; set; }
        public virtual ReferenceInterest ReferenceInterest { get; set; }
        public int Duration { get; set; }
        public decimal InterestPercentage { get; set; }
        public IRType IRType { get; set; }
        public int LoanProductId { get; set; }
        public virtual LoanProduct LoanProduct { get; set; }
        public string CurrencyCode { get; set; }
        public virtual Currency Currency { get; set; }
        public bool IsBankClient { get; set; }

        public decimal? LoanAmountFrom { get; set; }
        public decimal? LoanAmountTo { get; set; }
        public int? DurationFrom { get; set; }
        public int? DurationTo { get; set; }
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
    }
}
