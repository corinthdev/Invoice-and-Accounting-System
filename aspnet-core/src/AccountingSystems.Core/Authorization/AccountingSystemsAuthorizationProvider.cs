using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace AccountingSystems.Authorization
{
    public class AccountingSystemsAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Master, L("Master"));
            context.CreatePermission(PermissionNames.Pages_Transaction, L("Transaction"));
            context.CreatePermission(PermissionNames.Pages_Report, L("Report"));
            context.CreatePermission(PermissionNames.Pages_Inventory, L("InventoryMaintenance"));
            context.CreatePermission(PermissionNames.Pages_AccountReceivable, L("AccountReceivable"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AccountingSystemsConsts.LocalizationSourceName);
        }
    }
}
