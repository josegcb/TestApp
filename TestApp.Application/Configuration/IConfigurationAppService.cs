using System.Threading.Tasks;
using Abp.Application.Services;
using TestApp.Configuration.Dto;

namespace TestApp.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}