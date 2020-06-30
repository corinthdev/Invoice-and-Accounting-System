using Abp.Application.Navigation;
using Abp.Localization;
using AccountingSystems.Authorization;

namespace AccountingSystems.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class AccountingSystemsNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Tenants
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "people",
                        requiredPermissionName: PermissionNames.Pages_Users
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "local_offer",
                        requiredPermissionName: PermissionNames.Pages_Roles
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Transaction Maintenance",
                        L("Transaction"),
                        icon: "receipt",
                        requiredPermissionName: PermissionNames.Pages_Transaction
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Invoice,
                            L("Invoice"),
                            url: "Invoice"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.ExTruckSales,
                            L("ExTruckSales"),
                            url: "ExtruckSales"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Booking,
                            L("Booking"),
                            url: "Booking"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.PurchaseOrder,
                            L("PurchaseOrder"),
                            url: "PurchaseOrder"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.CreditMemo,
                            L("CreditMemo"),
                            url: "CreditMemo"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.ReturnCM,
                            L("ReturnCM"),
                            url: "DebitMemo"
                        )
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Report Maintenance",
                        L("Report"),
                        icon: "note_add",
                        requiredPermissionName: PermissionNames.Pages_Report
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.GatePass,
                            L("Gatepass"),
                            url: "Gatepass"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.SalesReport,
                            L("SalesReport"),
                            url: "Reports"
                        )
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Master Maintenance",
                        L("Master"),
                        icon: "dashboard",
                        requiredPermissionName: PermissionNames.Pages_Master
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Salesman,
                            L("Salesman"),
                            url: "Salesman"
                        )   
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Customer,
                            L("Customer"),
                            url: "Customer"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Supplier,
                            L("Supplier"),
                            url: "Supplier"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Product,
                            L("Product"),
                            url: "Product"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.RetailEnvironment,
                            L("RetailEnvironment"),
                            url: "RetailEnvironment"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.LocationSite,
                            L("LocationSite"),
                            url: "LocationSite"
                        )
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Inventory Maintenance",
                        L("InventoryMaintenance"),
                        icon: "assignment",
                        requiredPermissionName: PermissionNames.Pages_Inventory
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.CurrentStock,
                            L("CurrentStock"),
                            url: "Stocks"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.BadStock,
                            L("BadStock"),
                            url: "BadStock"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Expiry,
                            L("ExpiryMaintenance"),
                            url: "Inventory/Expiry"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.ExTruck,
                            L("ExTruck")
                        ).AddItem(
                            new MenuItemDefinition(
                                PageNames.ExTruckWith,
                                L("ExTruckWith"),
                                url: "Withdrawals"
                            )
                         ).AddItem(
                            new MenuItemDefinition(
                                PageNames.ExTruckUnload,
                                L("ExTruckUnload"),
                                url: "Unload"
                            )
                         ).AddItem(
                            new MenuItemDefinition(
                                PageNames.VanInventory,
                                L("VanInventory"),
                                url: "VanWarehouse"
                            )
                         )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.TransferStock,
                            L("Transfer"),
                            url: "TransferStock"
                        )
                    )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "Account Receivable Maintenance",
                        L("AccountReceivableMaintenance"),
                        icon: "monetization_on",
                        requiredPermissionName: PermissionNames.Pages_AccountReceivable
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.AR,
                            L("AccountReceivable"),
                            url: "AccountReceivable"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.ARReport,
                            L("AccountReceivableReports"),
                            url: "ARReport"
                        )
                    ).AddItem(
                        new MenuItemDefinition(
                            PageNames.Payment,
                            L("PaymentMaintenance"),
                            url: "Payment"
                        )
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AccountingSystemsConsts.LocalizationSourceName);
        }
    }
}
