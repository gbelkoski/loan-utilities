namespace FinanceUtilities.Core.Services
{
    public interface IQuoteRequestService
    {
        bool SendLoanQuoteRequest(string name, string customerEmail, string phoneNumber, string city, string mailContent, int loanId, decimal loanAmount, int duration);
        bool IsSpam(string customerEmail, string phoneNumber, int loanId);
    }
}