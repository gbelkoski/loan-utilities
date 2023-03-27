using System.ComponentModel.DataAnnotations;

namespace FinanceUtilities.Domain
{
    public class Currency
    {
        [Key]
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
