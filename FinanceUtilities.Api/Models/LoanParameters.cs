using System.ComponentModel.DataAnnotations;

namespace FinanceUtilities.Api.Models
{
    public class LoanParameters
    {
        public int? Years { get; set; }
        public decimal? Amount { get; set; }
        public decimal? InterestPercentage { get; set; }
    }
}