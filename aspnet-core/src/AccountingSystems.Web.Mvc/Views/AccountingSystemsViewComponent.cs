using Abp.AspNetCore.Mvc.ViewComponents;

namespace AccountingSystems.Web.Views
{
    public abstract class AccountingSystemsViewComponent : AbpViewComponent
    {
        protected AccountingSystemsViewComponent()
        {
            LocalizationSourceName = AccountingSystemsConsts.LocalizationSourceName;
        }
    }
}
