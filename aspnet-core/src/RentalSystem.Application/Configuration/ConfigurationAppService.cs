using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using RentalSystem.Configuration.Dto;

namespace RentalSystem.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : RentalSystemAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
