using System.Threading.Tasks;
using RentalSystem.Configuration.Dto;

namespace RentalSystem.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
