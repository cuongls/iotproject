using Abp.Application.Services;
using Abp.Application.Services.Dto;
using IOTProject.MultiTenancy.Dto;

namespace IOTProject.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
