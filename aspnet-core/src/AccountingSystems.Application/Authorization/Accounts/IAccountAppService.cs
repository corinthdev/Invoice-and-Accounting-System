using System.Threading.Tasks;
using Abp.Application.Services;
using AccountingSystems.Authorization.Accounts.Dto;

namespace AccountingSystems.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
