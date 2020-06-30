using System.Threading.Tasks;
using Abp.Application.Services;
using AccountingSystems.Sessions.Dto;

namespace AccountingSystems.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
