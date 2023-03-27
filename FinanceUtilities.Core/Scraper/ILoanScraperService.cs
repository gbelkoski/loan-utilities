namespace FinanceUtilities.Core
{
    public interface ILoanScraperService
    {
        bool UpdateLoanMarkup(int loanId);
        void LoanUpdateDone(int loanId);
        void ScrapeAllLoanProducts();
    }
}
