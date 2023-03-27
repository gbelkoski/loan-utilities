using FinanceUtilities.Domain;
using Microsoft.EntityFrameworkCore;

namespace FinanceUtilities.Data
{
    public class FinanceContext : DbContext, IFinanceContext
    {
        private string connectionString;

        public FinanceContext(DbContextOptions<FinanceContext> options)
            : base(options)
        { }

        public FinanceContext(DbContextOptions options, string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Used when instantiating db context outside IoC 
            if (connectionString != null)
            {
                var config = connectionString;
                optionsBuilder.UseSqlServer(config);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Commented because it would not work with mysql
            //modelBuilder.HasDefaultSchema("dbo");
        }

        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<GlobalSettings> GlobalSettings { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }
        public virtual DbSet<LoanProduct> LoanProducts { get; set; }
        public virtual DbSet<InterestPeriod> InterestPeriods { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<LoanProductExpenseType> LoanProductExpenseTypes { get; set; }
        public virtual DbSet<ReferenceInterest> ReferenceInterests { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<QuoteLog> QuoteLogs { get; set; }
    }
}
