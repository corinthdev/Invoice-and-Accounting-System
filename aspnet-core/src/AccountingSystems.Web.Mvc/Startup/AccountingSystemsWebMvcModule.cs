using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AccountingSystems.Configuration;
using Abp.Dependency;

namespace AccountingSystems.Web.Startup
{
    [DependsOn(typeof(AccountingSystemsWebCoreModule))]
    public class AccountingSystemsWebMvcModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AccountingSystemsWebMvcModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.Navigation.Providers.Add<AccountingSystemsNavigationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AccountingSystemsWebMvcModule).GetAssembly());
        }
    }
}
