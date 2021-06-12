using Abp.Application.Services;
using RentalSystem.MultiTenancy.Dto;

namespace RentalSystem.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

