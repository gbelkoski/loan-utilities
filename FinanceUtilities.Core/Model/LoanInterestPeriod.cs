using FinanceUtilities.Domain;

namespace FinanceUtilities.Core.Model
{
    public class LoanInterestPeriod
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public string ReferenceInterestId { get; set; }
        public int Duration { get; set; }
        public decimal InterestPercentage { get; set; }
        public IRType IRType{ get; set; }
        public decimal Minimum { get; set; }
        public decimal Maximum { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsBankClient { get; set; }
        public decimal?  LoanAmountFrom { get; set; }
        public decimal? LoanAmountTo { get; set; }
        public int? DurationFrom { get; set; }
        public int? DurationTo { get; set; }
    }
}
