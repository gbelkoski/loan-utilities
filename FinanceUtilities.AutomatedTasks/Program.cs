using FinanceUtilities.Core;
using FinanceUtilities.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceUtilities.AutomatedTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            ILoanScraperService scraper = new LoanScraperService(BuildContext());
            scraper.ScrapeAllLoanProducts();
        }

        private static FinanceContext BuildContext()
        {
            var builder = new DbContextOptionsBuilder<FinanceContext>();
            var connectionString = "Server=164.68.105.233;Database=seznajko;User Id=sa; password=S3znajk0;encrypt=true; TrustServerCertificate=True";//configuration.GetConnectionString("FinanceDatabase");
            builder.UseSqlServer(connectionString);
            return new FinanceContext(builder.Options);
        }
    }
}
