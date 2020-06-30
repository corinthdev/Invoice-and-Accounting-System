using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AccountingSystems.Controllers
{
    public abstract class AccountingSystemsControllerBase: AbpController
    {
        protected AccountingSystemsControllerBase()
        {
            LocalizationSourceName = AccountingSystemsConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
