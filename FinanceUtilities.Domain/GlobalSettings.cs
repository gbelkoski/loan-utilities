using System.ComponentModel.DataAnnotations;

namespace FinanceUtilities.Domain
{
    public class GlobalSettings
    {
        [Key]
        public int Id { get; set; }
        public decimal MaxAllowedInterestPercentage { get; set; }
    }
}
