using Abp.Application.Services;
using Abp.Application.Services.Dto;
using TestApp.MultiTenancy.Dto;

namespace TestApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
