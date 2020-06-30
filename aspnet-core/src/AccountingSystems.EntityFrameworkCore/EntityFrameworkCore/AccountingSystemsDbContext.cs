using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AccountingSystems.Authorization.Roles;
using AccountingSystems.Authorization.Users;
using AccountingSystems.MultiTenancy;
using AccountingSystems.Salesmans;
using AccountingSystems.Vans;
using AccountingSystems.Customers;
using AccountingSystems.Suppliers;
using AccountingSystems.Products;
using AccountingSystems.InvoiceHeaders;
using AccountingSystems.InvoiceDetails;
using AccountingSystems.PurchaseOrderHeaders;
using AccountingSystems.PurchaseOrderDetails;
using AccountingSystems.CreditMemoHeaders;
using AccountingSystems.CreditMemoDetails;
using AccountingSystems.DebitMemoHeaders;
using AccountingSystems.DebitMemoDetails;
using AccountingSystems.RetailEnvironments;
using AccountingSystems.BookingHeaders;
using AccountingSystems.BookingDetails;
using AccountingSystems.Stocks;
using AccountingSystems.ExtruckSaleHeaders;
using AccountingSystems.ExtruckSaleDetails;
using AccountingSystems.BadStocks;
using AccountingSystems.VanStocks;
using AccountingSystems.WithdrawalHeaders;
using AccountingSystems.WithdrawalDetails;
using AccountingSystems.UnloadHeaders;
using AccountingSystems.UnloadDetails;
using AccountingSystems.Sites;

namespace AccountingSystems.EntityFrameworkCore
{
    public class AccountingSystemsDbContext : AbpZeroDbContext<Tenant, Role, User, AccountingSystemsDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AccountingSystemsDbContext(DbContextOptions<AccountingSystemsDbContext> options)
            : base(options)
        {
        }
        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<BookingHeader> BookingHeaders { get; set; }
        public DbSet<BookingDetail> BookingDetails { get; set; }
        public DbSet<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<CreditMemoHeader> CreditMemoHeaders { get; set; }
        public DbSet<CreditMemoDetail> CreditMemoDetails { get; set; }
        public DbSet<DebitMemoHeader> DebitMemoHeaders { get; set; }
        public DbSet<DebitMemoDetail> DebitMemoDetails { get; set; }
        public DbSet<ExtruckSaleHeader> ExtruckSaleHeaders { get; set; }
        public DbSet<ExtruckSaleDetail> ExtructSaleDetails { get; set; }
        public DbSet<WithdrawalHeader> WithdrawalHeaders { get; set; }
        public DbSet<WithdrawalDetail> WithdrawalDetails { get; set; }
        public DbSet<UnloadHeader> UnloadHeaders { get; set; }
        public DbSet<UnloadDetail> UnloadDetails { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Van> Vans { get; set; }
        public DbSet<VanStock> VanStocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RetailEnvironment> RetailEnvironments { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<BadStock> BadStocks { get; set; }
        public DbSet<LocationSite> LocationSites { get; set; }
    }
}
