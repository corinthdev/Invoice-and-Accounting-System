using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AccountingSystems.Configuration;

namespace AccountingSystems.Web.Host.Startup
{
    [DependsOn(
       typeof(AccountingSystemsWebCoreModule))]
    public class AccountingSystemsWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AccountingSystemsWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AccountingSystemsWebHostModule).GetAssembly());
        }
    }
}
