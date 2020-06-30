using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using AccountingSystems.Configuration.Dto;

namespace AccountingSystems.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : AccountingSystemsAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
