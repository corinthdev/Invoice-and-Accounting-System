using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.MultiTenancy.Dto;

namespace AccountingSystems.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

