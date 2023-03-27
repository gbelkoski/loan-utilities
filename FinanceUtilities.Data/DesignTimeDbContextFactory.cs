using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FinanceUtilities.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FinanceContext>
    {
        const string ConnectionString = "Server=94.155.47.59;Database=fbiewrsoseznajkotest;User Id=fbiewrsogjorgji; password=Krediti987!;encrypt=true; TrustServerCertificate=True";
        //const string ConnectionString = "Server=127.0.0.1;Database=fbiewrsoseznajko;Uid=gjorgji;Pwd=P@ssw0rd";

        public FinanceContext CreateDbContext(string[] args)
        {
            return CreateMsSqlServer();
        }

        private FinanceContext CreateMsSqlServer()
        {
            var builder = new DbContextOptionsBuilder<FinanceContext>();

            builder.UseSqlServer(ConnectionString);
            return new FinanceContext(builder.Options);
        }

        //private FinanceContext CreateMySqlServer()
        //{
        //    var builder = new DbContextOptionsBuilder<FinanceContext>();

        //    builder.UseMySql(ConnectionString);
        //    return new FinanceContext(builder.Options);
        //}
    }
}
