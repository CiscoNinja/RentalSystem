using System.Threading.Tasks;
using Abp.Application.Services;
using RentalSystem.Authorization.Accounts.Dto;

namespace RentalSystem.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
