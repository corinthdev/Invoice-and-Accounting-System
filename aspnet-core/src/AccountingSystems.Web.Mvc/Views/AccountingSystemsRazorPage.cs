using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace AccountingSystems.Web.Views
{
    public abstract class AccountingSystemsRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected AccountingSystemsRazorPage()
        {
            LocalizationSourceName = AccountingSystemsConsts.LocalizationSourceName;
        }
    }
}
