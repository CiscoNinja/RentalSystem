using System.Threading.Tasks;
using Abp.Application.Services;
using RentalSystem.Sessions.Dto;

namespace RentalSystem.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
