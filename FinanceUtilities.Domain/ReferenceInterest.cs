using System;

namespace FinanceUtilities.Domain
{
    public class ReferenceInterest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptionEn { get; set; }
        public decimal Rate { get; set; }
        public DateTime Date { get; set; }
        public string TenorInMonths { get; set; }
        public string CurrencyCode { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
