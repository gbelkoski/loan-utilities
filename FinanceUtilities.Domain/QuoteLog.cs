using System;

namespace FinanceUtilities.Domain
{
    public class QuoteLog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public int LoanProductId { get; set; }
        public virtual LoanProduct LoanProduct { get; set; }
        public decimal LoanAmount { get; set; }
        public int Duration { get; set; }
        public bool MailSentSuccessfully { get; set; }
        public string TermsOfApplication { get; set; }
    }
}
