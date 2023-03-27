using System.ComponentModel.DataAnnotations;

namespace FinanceUtilities.Domain
{
    public class LoanType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameEN { get; set; }
        public string Description { get; set; }
        public string DescriptionEN { get; set; }
    }
}
