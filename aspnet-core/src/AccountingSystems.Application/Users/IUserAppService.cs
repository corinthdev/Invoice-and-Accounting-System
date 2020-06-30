using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using AccountingSystems.Roles.Dto;
using AccountingSystems.Users.Dto;

namespace AccountingSystems.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
