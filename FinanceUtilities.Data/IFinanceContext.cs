using FinanceUtilities.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceUtilities.Data
{
    public interface IFinanceContext
    {
        DbSet<Bank> Banks { get; set; }
        DbSet<GlobalSettings> GlobalSettings { get; set; }
        DbSet<LoanType> LoanTypes { get; set; }
        DbSet<LoanProduct> LoanProducts { get; set; }
        DbSet<InterestPeriod> InterestPeriods { get; set; }
        DbSet<ExpenseType> ExpenseTypes { get; set; }
        DbSet<LoanProductExpenseType> LoanProductExpenseTypes { get; set; }
        DbSet<ReferenceInterest> ReferenceInterests { get; set; }
        DbSet<Currency> Currencies { get; set; }
        DbSet<QuoteLog> QuoteLogs { get; set; }

        int SaveChanges();
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
