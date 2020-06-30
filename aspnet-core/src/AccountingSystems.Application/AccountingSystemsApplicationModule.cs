using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AccountingSystems.Authorization;

namespace AccountingSystems
{
    [DependsOn(
        typeof(AccountingSystemsCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class AccountingSystemsApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<AccountingSystemsAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(AccountingSystemsApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
