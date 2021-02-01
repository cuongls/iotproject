using System.Threading.Tasks;
using Abp.Application.Services;
using IOTProject.Configuration.Dto;

namespace IOTProject.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}