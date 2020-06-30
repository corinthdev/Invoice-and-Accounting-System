using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AccountingSystems.EntityFrameworkCore
{
    public static class AccountingSystemsDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AccountingSystemsDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AccountingSystemsDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
