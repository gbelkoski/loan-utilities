namespace FinanceUtilities.Api.Models
{
    public class LoanQuoteRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Content { get; set; }
        public int LoanId { get; set; }
        public decimal LoanAmount { get; set; }
        public int Duration { get; set; }
    }
}