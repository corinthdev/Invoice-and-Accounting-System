using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using AccountingSystems.Configuration;
using AccountingSystems.Web;

namespace AccountingSystems.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AccountingSystemsDbContextFactory : IDesignTimeDbContextFactory<AccountingSystemsDbContext>
    {
        public AccountingSystemsDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AccountingSystemsDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AccountingSystemsDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AccountingSystemsConsts.ConnectionStringName));

            return new AccountingSystemsDbContext(builder.Options);
        }
    }
}
