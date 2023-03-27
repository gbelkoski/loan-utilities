namespace FinanceUtilities.Core
{
    public interface IEmailService
    {
        bool SendLoanQuoteRequest(string name, string email, string phoneNumber, string city, string mailContent, int loanId, decimal loanAmount, int years);
        bool SendContactMail(string name, string email, string phoneNumber, string mailContent);
    }
}
