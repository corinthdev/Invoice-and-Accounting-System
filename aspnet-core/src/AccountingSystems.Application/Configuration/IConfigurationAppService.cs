using System.Threading.Tasks;
using AccountingSystems.Configuration.Dto;

namespace AccountingSystems.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
