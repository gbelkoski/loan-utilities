using System.ComponentModel.DataAnnotations;

namespace FinanceUtilities.Api.Models
{
    public class LoanTotals
    {
        public int Id { get; set; }
        public string BankLogo { get; set; }
        public string BankName { get; set; }
        [Display(Name = "Рата")]
        public decimal InstallmentAmount { get; set; }
        [Display(Name = "Вкупно камата")]
        public decimal TotalInterest { get; set; }
        [Display(Name = "Вкупно за враќање")]
        public decimal Total { get; set; }
    }
}