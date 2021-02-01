using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using IOTProject.Configuration.Dto;

namespace IOTProject.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : IOTProjectAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
